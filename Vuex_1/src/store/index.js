import { createStore } from "vuex";

function checkDish(d, filter){
  for (const key in filter){
    if (filter[key] && filter[key] !== d[key]) return false
  }
  return true
}

// Меню ресторану. База даних страв: назва страви, одиниці вимірювання, вартість одиниці, страва якої кухні (національна приналежність). 
// Організувати вибір за довільним запитом.

export default createStore({
  state: {
    dishes: [
      {
        id: 1,
        title: 'Люля-кебаб',
        measurement: 300,
        price: 364,
        nationality: 'Грузія'
      },
      {
        id: 2,
        title: 'Борщ',
        measurement: 200,
        price: 150,
        nationality: 'Україна'
      },
      {
        id: 3,
        title: 'Суші',
        measurement: 950,
        price: 420,
        nationality: 'Японія'
      },
      {
        id: 4,
        title: 'Вареники',
        measurement: 200,
        price: 90,
        nationality: 'Україна'
      },
      {
        id: 5,
        title: 'Хінкалі',
        measurement: 425,
        price: 180,
        nationality: 'Грузія'
      },
      {
        id: 6,
        title: 'Піца',
        measurement: 350,
        price: 210,
        nationality: 'Італія'
      },
    ],
    filterObj: {},
  },
  getters: {
    getDishes: ({dishes, filterObj}) => dishes.filter((d) => checkDish(d, filterObj)),
    getDishById: (state) => {
      return (dishId) => state.dishes.find((d) => d.id !== dishId)
    }
  },
  mutations: {
    removeDish(state, dishId) {
      state.dishes = state.dishes.filter((d) => d.id !== dishId)
    },
    addDish(state, dish) {
      state.dishes.push(dish)
    },
    updateDish(state, dish){
      const dishIndex = state.dishes.findIndex((d) => d.id == dish.id)
      state.dishes[dishIndex] = dish
    },
    updateFilter(state, filter){
      state.filterObj = filter
    },
  },
  actions: {
    deleteDish({commit}, idToRemove){
      commit('removeDish', idToRemove)
    },
    onAddDish({commit}, dishObj) {
      commit('addDish', {
        id: new Date().getTime(),
        ...dishObj,
      })
    },
    onUpdateDish({commit}, dish){
      commit('updateDish', dish)
    },
    onUpdateFilter({commit}, filter){
      commit('updateFilter', filter)
    }
  },
  modules: {},
});
