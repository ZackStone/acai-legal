<template>
  <form v-show="isLoaded">
    <v-card v-show="!showCheckout">
      <v-card-title>
        Realizar Pedido
      </v-card-title>
      <v-card-text>
        <v-container fluid>
          <v-row>
            <v-col cols="6">
              <v-radio-group
                v-model="model.tamanho"
                label="Tamanho"
                :error-messages="errorsTamanho"
              >
                <v-radio
                  v-for="item in items.tamanhos"
                  :key="item.id"
                  :value="item"
                  :label="
                    `${item.label} (${item.tamanhoMl}ml) - ${$n(
                      item.preco,
                      'currency'
                    )}`
                  "
                ></v-radio>
              </v-radio-group>
            </v-col>
            <v-col cols="6">
              <v-radio-group
                v-model="model.sabor"
                label="Sabor"
                :error-messages="errorsSabor"
              >
                <v-radio
                  v-for="item in items.sabores"
                  :key="item.id"
                  :value="item"
                  :label="item.label"
                ></v-radio>
              </v-radio-group>
            </v-col>
            <v-col cols="12">
              <div class="text-left">
                Adicionais
              </div>
              <v-item-group v-model="model.adicionais" :multiple="true">
                <v-item
                  v-for="item in items.adicionais"
                  v-slot:default="{ active, toggle }"
                  :key="item.id"
                  :value="item"
                >
                  <v-checkbox
                    :label="`${item.label} - ${$preco(item.preco, 'Grátis')}`"
                    :input-value="active"
                    @change="toggle"
                  ></v-checkbox>
                </v-item>
              </v-item-group>
            </v-col>
          </v-row>
        </v-container>
      </v-card-text>
      <v-card-actions>
        <v-btn color="primary" large @click="fazerCheckout">Checkout</v-btn>
        <v-btn color="accent" large @click="clear">Limpar</v-btn>
      </v-card-actions>
    </v-card>
    <v-card v-if="showCheckout">
      <v-card-title>
        Checkout
      </v-card-title>
      <v-card-text>
        <pedido v-model="model" />
      </v-card-text>
      <v-card-actions>
        <v-btn color="primary" large @click="submit">Finalizar Pedido</v-btn>
        <v-btn color="accent" large @click="showCheckout = false">Voltar</v-btn>
      </v-card-actions>
    </v-card>
  </form>
</template>

<script>
import { validationMixin } from 'vuelidate'
import { required } from 'vuelidate/lib/validators'
import Pedido from '~/components/Pedido.vue'

export default {
  components: {
    Pedido
  },

  mixins: [validationMixin],

  validations: {
    model: {
      tamanho: { required },
      sabor: { required }
    }
  },

  data: () => ({
    isLoaded: false,
    showCheckout: false,
    model: {
      precoTotal: 0,
      tempoDePreparo: 0
    },
    items: {
      tamanhos: [],
      sabores: [],
      adicionais: []
    }
  }),

  computed: {
    errorsTamanho() {
      return this.errorsRadioGroup('tamanho')
    },
    errorsSabor() {
      return this.errorsRadioGroup('sabor')
    }
  },

  beforeMount() {
    this.$nextTick(() => {
      this.$nuxt.$loading.start()
    })

    this.reqs = [
      this.getItems('tamanhos'),
      this.getItems('sabores'),
      this.getItems('adicionais')
    ]

    Promise.all(this.reqs).then((_) => {
      this.$nuxt.$loading.finish()
      this.isLoaded = true
    })
  },

  methods: {
    getItems(type) {
      return this.$repositories[type]
        .getAll()
        .then((data) => (this.items[type] = data))
    },
    errorsRadioGroup(field) {
      const errors = []
      if (!this.$v.model[field].$dirty) return errors
      !this.$v.model[field].required && errors.push('Campo obrigatório')
      return errors
    },
    getPayload() {
      return {
        tamanhoId: this.model.tamanho.id,
        saborId: this.model.sabor.id,
        adicionais:
          this.model.adicionais && this.model.adicionais.map((a) => a.id)
      }
    },
    async fazerCheckout() {
      this.$v.$touch()
      if (this.$v.$invalid) return

      this.$nuxt.$loading.start()

      const { data } = await this.$axios.post(
        '/api/pedidos/checkout',
        this.getPayload()
      )
      this.model.precoTotal = data.precoTotal
      this.model.tempoDePreparo = data.tempoDePreparo

      this.showCheckout = true
      this.$nuxt.$loading.finish()
    },
    async submit() {
      this.$v.$touch()
      if (this.$v.$invalid) return

      this.$nuxt.$loading.start()

      const pedido = await this.$repositories.pedidos.post(this.getPayload())

      this.$nuxt.$loading.finish()

      this.$router.push(`/pedidos/${pedido.id}`)
    },
    clear() {
      this.$v.model.$reset()
      this.model = {}
    }
  }
}
</script>
