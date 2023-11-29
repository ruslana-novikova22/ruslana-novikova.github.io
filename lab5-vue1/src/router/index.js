import { createRouter, createWebHistory } from 'vue-router'
import HomeView from '../views/HomeView.vue'
import LessonsView from '../views/LessonsView.vue'
import TeachersView from "../views/TeachersView.vue";
import PageNotFound from "../views/PageNotFound.vue";

const routes = [
  {
    path: '/',
    name: 'home',
    component: HomeView
  },
  {
    path: "/login",
    name: "loginPage",
    component: ()=> import("../views/LoginView.vue"),
  },
  {
    path: "/check/:lessonTeacherPairs",
    name: "check",
    component: ()=> import("../views/CheckView.vue"),
  },
  {
    path: "/lessons",
    name: "lessons",
    component: LessonsView,
    children:[
      {
        path: "/lessons/select",
        name: "select",
        component: LessonsView,
      },
    ]
  },
  {
    path: '/teacher',
    name: 'teacher',
    component: TeachersView,
    props: (route) => ({ lessonIds: route.query.lessonIds }),
  },
  {
    path: '/page-not-found',
    name: 'PageNotFound',
    component: PageNotFound,
  },
  {
    path: '/:catchAll(.*)',
    redirect: '/page-not-found',
  },
  {
    path: '/about',
    name: 'about',
    // route level code-splitting
    // this generates a separate chunk (about.[hash].js) for this route
    // which is lazy-loaded when the route is visited.
    component: () => import(/* webpackChunkName: "about" */ '../views/AboutView.vue')
  }
]

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes,
  encodeQuery: false, 
  encodeParams: false, 
})

export default router
