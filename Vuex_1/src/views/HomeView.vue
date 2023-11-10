<template>
  <div class="home">
    <menu-filter/>
    <button @click="onCreate">Створити страву</button>
    <menu-list/>
  </div>
</template>

<script>
import MenuList from '@/components/MenuList.vue'
import MenuFilter from '@/components/MenuFilter.vue';

export default {
    name: 'HomeView',
    components: {
        MenuList,
        MenuFilter,
    },

    methods: {
      onCreate(){
        this.$router.push({
          name: 'config',
        })
      },
    },
};
</script>
