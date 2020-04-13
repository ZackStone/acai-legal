<template>
  <form v-if="isLoaded">
    <v-card>
      <v-card-title>
        Pedido Finalizado
      </v-card-title>
      <v-card-text>
        <pedido v-model="model" />
      </v-card-text>
      <v-card-actions>
        <v-btn color="primary" large @click="novoPedido">Novo Pedido</v-btn>
      </v-card-actions>
    </v-card>
  </form>
</template>

<script>
import Pedido from '~/components/Pedido.vue'

export default {
  components: {
    Pedido
  },

  data: () => ({
    isLoaded: false,
    model: {
      precoTotal: 0,
      tempoDePreparo: 0
    }
  }),

  async beforeMount() {
    this.$nextTick(() => {
      this.$nuxt.$loading.start()
    })

    const pedido = await this.$repositories.pedidos.get(this.$route.params.id)
    this.model = pedido
    this.model.adicionais = pedido.adicionais.map((a) => a.adicional)

    this.$nuxt.$loading.finish()
    this.isLoaded = true
  },

  methods: {
    novoPedido() {
      this.$router.push('/fazer-pedido')
    }
  }
}
</script>
