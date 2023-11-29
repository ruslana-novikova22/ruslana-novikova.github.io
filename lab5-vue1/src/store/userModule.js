const state = {
    users: {},
  };
  const mutations = {
    setUserData(state, { username, data }) {
      state.users = {
        ...state.users,
        [username]: data,
      };
    },
  };
  
  const actions = {
    ['user/login']({ commit }, userData) {
      commit("setUserData", { username: userData.username, data: userData });
    },
  };
  
  const getters = {
    userData: (state) => Object.values(state.users),
  };
  
  export default {
    state,
    mutations,
    actions,
    getters,
  };
 