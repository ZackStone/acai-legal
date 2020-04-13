<template>
  <div>
    <v-simple-table>
      <template v-slot:default>
        <thead>
          <tr>
            <th class="text-left">Item</th>
            <th class="text-left">Valor</th>
          </tr>
        </thead>
        <tbody>
          <tr>
            <td class="text-left">
              {{ `Açaí ${value.tamanho.label} Sabor ${value.sabor.label}` }}
            </td>
            <td class="text-left">
              {{ $preco(value.tamanho.preco, '0') }}
            </td>
          </tr>
          <tr v-for="item in value.adicionais" :key="item.id">
            <td class="text-left">{{ `Adicional: ${item.label}` }}</td>
            <td class="text-left">{{ $preco(item.preco, 'Grátis') }}</td>
          </tr>
          <tr>
            <td class="text-left display-1">Total</td>
            <td class="text-left display-1">
              {{ $preco(value.precoTotal, 'Grátis') }}
            </td>
          </tr>
        </tbody>
      </template>
    </v-simple-table>
    <v-divider></v-divider>
    <div class="text-left my-4 subtitle-1">
      Tempo de preparo: {{ value.tempoDePreparo }} min
    </div>
  </div>
</template>

<script>
export default {
  props: {
    value: {
      type: Object,
      default() {
        return {}
      }
    }
  }
}
</script>
