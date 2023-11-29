<template>
  <div>
    <h1>Вибрані уроки:</h1>
    <ul>
      <li v-for="lessonId in lessonIdsArray" :key="lessonId">
        {{ getLessonName(lessonId) }}
        <select v-model="selectedTeacher[lessonId]">
          <option v-for="teacher in teachersList" :key="teacher.id" :value="teacher.id">
            {{ teacher.name }}
          </option>
        </select>
      </li>
    </ul>
    <button @click="startLearning">Перейти до навчального плану</button>
  </div>
</template>

<script>
import { mapGetters } from 'vuex';

export default {
  name: "TeacherView",
  props: {
    lessonIds: {
      type: String,
      required: true,
    },
  },
  data() {
    return {
      selectedTeacher: {},
    };
  },
  computed: {
    ...mapGetters(['getTeachers', 'getLessonById']),
    lessonIdsArray() {
      return this.lessonIds.split('/');
    },
    teachersList() {
      return this.getTeachers;
    },
  },
  methods: {
    getLessonName(lessonId) {
      const lesson = this.getLessonById(lessonId);
      return lesson ? lesson.title : `Урок з ID ${lessonId}`;
    },

    startLearning() {
      if (Object.keys(this.selectedTeacher).length > 0) {
        const lessonTeacherPairs = this.lessonIdsArray.map(
          (lessonId) => `${lessonId}-${this.selectedTeacher[lessonId]}`
        );
        const lessonTeacherPairsString = lessonTeacherPairs.join('/');
        this.$router.push({ name: 'check', params: { lessonTeacherPairs: lessonTeacherPairsString } });
      } else {
        this.$router.push({ name: 'PageNotFound' });
      }
    },
  },
};
</script>

<style lang="scss" scoped>
</style>
