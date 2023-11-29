<template>
    <div>
      <h1>Login</h1>
      <form @submit.prevent="login">
        <label for="username">Username:</label>
        <input type="text" id="username" v-model="username" required />
  
        <label for="password">Password:</label>
        <input type="password" id="password" v-model="password" required />
  
        <button type="submit">Login</button>
      </form>
      <button @click="redirectToRegistration">Go to Registration</button>
  
      <div>
        <button @click="displayUserData">Display User Data</button>
        <label for="userId">User ID:</label>
        <input type="text" id="userId" v-model="userId" />
      </div>
  
      <div v-if="userData && userData.length > 0">
        <h2>Збережені дані користувачів:</h2>
        <div v-for="(user, index) in userData" :key="index">
          <p>
            <strong>ID:</strong> {{ user.id }}
          </p>
          <p>Ім'я користувача: {{ user.username }}</p>
          <p>Пароль: {{ user.password }}</p>
        </div>
      </div>
    </div>
  </template>
  
  <script>
  export default {
    name: "LoginView",
    data() {
      return {
        username: "",
        password: "",
        userId: null,
      };
    },
    computed: {
      userData() {
        return this.$store.getters["user/userData"];
      },
    },
    methods: {
      login() {
        this.$store.dispatch("user/login", {
          id: new Date().getTime(),
          username: this.username,
          password: this.password,
        });
      },
      redirectToRegistration() {
        this.$router.push({ name: "select" });
      },
      displayUserData() {
        if (this.userId !== null && this.userData) {
          const user = this.userData.find((user) => user.id === this.userId);
          if (user) {
            alert(
              `ID: ${user.id}\nІм'я користувача: ${user.username}\nДані: ${JSON.stringify(user)}`
            );
          } else {
            alert(`Користувача з ID ${this.userId} не знайдено.`);
          }
        } else {
          alert('Будь ласка, введіть ID користувача.');
        }
      },
    },
  };
  </script>
  
  <style scoped>
  
  </style>