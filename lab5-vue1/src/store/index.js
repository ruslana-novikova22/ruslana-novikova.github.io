import { createStore } from 'vuex'
import teachersModule from './teachersModule';
import userModule from './userModule';

export default createStore({
  state: {
    lessons: [
      {id: 1, title: 'Українська мова'},
      {id: 2, title: 'Математика'},
      {id: 3, title: 'Англійська мова'},
      {id: 4, title: 'Історія України'},
      {id: 5, title: 'Фізика'},
      {id: 6,title: 'Географія'},
      {id: 7, title: 'Фізкультура'},
    ],
    
    selectedTeachers: {},
  },
  getters: {
    getLessons: (state) => state.lessons,
    getLessonById: (state) => {
      return (lessonId) => state.lessons.find((lesson) => lesson.id === parseInt(lessonId));
    },

    getTeachers: (state) => state.teachers,
    getTeacherById: (state) => state.selectedTeachers,
  },
  mutations: {
    updateTeachers (state, {lessonId, teacherId}) {
      state.selectedTeachers = {
        ...state.selectedTeachers,
        [lessonId]: teacherId
      };
    },
  },
  actions: {
    updateTeachers ({commit}, {lessonId, teacherId}) {
      commit('updateTeachers', {lessonId, teacherId})
    }
  },
  modules: {
    teachersModule,
    userModule
  }
})
