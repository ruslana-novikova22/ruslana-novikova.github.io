<template>
      <tr>
        <td>{{ dishObj.title }}</td>
        <td>{{ dishObj.measurement }} г</td>
        <td>{{ dishObj.price }} грн</td>
        <td>{{ dishObj.nationality }}</td>
        <td>
          <button @click="onEdit">Редагувати</button>
        </td>
        <td>
          <button @click="deleteDish(dishObj.id)">Видалити</button>
        </td>
      </tr>
</template>


<script>
import { mapActions } from 'vuex'

export default {
    name: 'MenuItem',

    props: {
        dishObj: {
            type: Object,
            default: () => ({}),
        },
    },

    methods: {
        ...mapActions(['deleteDish']),
        onEdit() {
          const dishDetails = this.$store.getters.getDishById(this.dishObj.id);
          this.$router.push({
            name: 'config',
            params: {
              dishId: this.dishObj.id,
              dishDetails: dishDetails, 
            },
          });
        },   
    }
}
</script>

<style>
.menu-table {
  width: 100%;
  border-collapse: collapse;
}

.menu-table th, .menu-table td {
  border: 1px solid #ccc;
  padding: 10px;
  text-align: center;
}

.menu-table th {
  background-color: #f2f2f2;
  font-weight: bold;
}

.menu-table tr:nth-child(even) {
  background-color: #f5f5f5;
}

.menu-table tr:hover {
  background-color: #e0e0e0;
}

.menu-table button {
  padding: 5px 10px;
  background-color: #007bff;
  color: #fff;
  border: none;
  cursor: pointer;
}

.menu-table button:hover {
  background-color: #0056b3;
}
</style>
