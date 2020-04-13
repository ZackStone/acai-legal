export default (ctx, inject) => {
  const preco = (value, fallback) => {
    return value ? ctx.app.i18n.n(value, 'currency') : fallback
  }

  inject('preco', preco)
}
