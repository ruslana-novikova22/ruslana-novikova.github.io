<template>
  <div>
    <h2>Виберіть предмети</h2>
    <div class="lesson-checkbox" v-for="lesson in filteredLessons" :key="lesson.id">
      <input type="checkbox" v-model="selectedLessons" :value="lesson.id" :id="'checkbox-' + lesson.id" />
      <label :for="'checkbox-' + lesson.id">{{ lesson.title }}</label>
    </div>
    <router-link v-if="selectedLessons.length > 0" :to="{ name: 'teacher', query: { lessonIds: selectedLessons.join('/') } }">
      <button>Вибрати вчителів</button>
    </router-link>
  </div>
</template>

<script>
import { mapGetters } from 'vuex';

export default {
  data() {
    return {
      selectedLessons: [],
    };
  },

  computed: {
    ...mapGetters(['getLessons']),
    filteredLessons() {
      return this.getLessons;
    },
    lessons: 'getLessons',
    teachers: 'teachers/getTeachers',
  },
};
</script>
