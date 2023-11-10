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
    </div>
</template>

<script>
import { mapActions } from "vuex";

export default {
    name: 'MenuFilter',

    data() {
        return {
            currentDish: {},
        }
    },

    watch: {
        currentDish:{
            handler(newFilter) {
                this.onUpdateFilter(newFilter)
            },
            deep: true,
        }
    },

    methods: {
        ...mapActions(['onUpdateFilter']),
    }
}
</script>

<style lang="scss" scoped>

</style>