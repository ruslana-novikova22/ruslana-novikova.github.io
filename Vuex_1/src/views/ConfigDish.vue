<template>
    <div>
        <div>
            <label>
                Назва
                <input v-model="currentDish.title" type="text"/>
            </label>
        </div>
        <div>
            <label>
                Величина одиниці
                <input v-model="currentDish.measurement" type="text"/>
            </label>
        </div>
        <div>
            <label>
                Ціна одиниці
                <input v-model="currentDish.price" type="text"/>
            </label>
        </div>
        <div>
            <label>
                Національна приналежність
                <input v-model="currentDish.nationality" type="text"/>
            </label>
        </div>
        <button @click="saveChanges">Зберегти</button>
    </div>
</template>

<script>
import { mapActions, mapGetters } from 'vuex'
export default {
    name: 'ConfigDish',

    data() {
        return{
            currentDish: {},
        }
    },

    computed: {
        ...mapGetters(['getDishById']),
        dishId(){
            return this.$route.params.dishId
        },
    },

    created(){
        if(this.dishId) this.currentDish = {...this.getDishById(this.dishId)}
    },
    
    methods: {
        ...mapActions(['onAddDish', 'onUpdateDish']),
        saveChanges() {
            if (this.dishId) {
                this.onUpdateDish(this.currentDish);
            } else {
                this.onAddDish(this.currentDish);
            }
            this.resetForm();
            },

        resetForm() {
        this.currentDish = {};
        this.$router.push({ path: '/' });
        },
    },
}
</script>

<style lang="scss" scoped>

</style>