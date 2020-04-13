export default ($axios) => (resource) => ({
  getAll() {
    return $axios.$get(`/api/${resource}`)
  },

  get(id) {
    return $axios.$get(`/api/${resource}/${id}`)
  },

  post(payload) {
    return $axios.$post(`/api/${resource}`, payload)
  },

  put(id, payload) {
    return $axios.$post(`/api/${resource}/${id}`, payload)
  },

  delete(id) {
    return $axios.$delete(`/api/${resource}/${id}`)
  }
})
