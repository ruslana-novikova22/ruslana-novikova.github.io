<template>
    <div>
    <table class="menu-table">
    <thead>
      <tr>
        <th>Назва страви</th>
        <th>Одиниці вимірювання</th>
        <th>Вартість одиниці</th>
        <th>Національна приналежність</th>
        <th>Редагування</th>
        <th>Видалення</th>
      </tr>
    </thead>
    <tbody>
        <menu-item v-for="dish in getDishes" :key="dish.id" :dish-obj ="dish"/>
    </tbody>
    </table>
    </div>
</template>

<script>
import { mapGetters } from "vuex";
import MenuItem from "./MenuItem.vue";

export default {
    name: 'MenuList',

    components: {
        MenuItem,
    },

    computed: {
        ...mapGetters(['getDishes']),
    }
}
</script>

<style lang="scss" scoped>

</style>