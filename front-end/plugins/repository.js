import createRepository from '~/api/Repository.js'

export default (ctx, inject) => {
  const repositoryWithAxios = createRepository(ctx.$axios)

  const repositories = {
    tamanhos: repositoryWithAxios('tamanhos'),
    sabores: repositoryWithAxios('sabores'),
    adicionais: repositoryWithAxios('adicionais'),
    pedidos: repositoryWithAxios('pedidos')
  }

  inject('repositories', repositories)
}
