export default{
    state:{
        teachers: [
            {
              id: 1,
              name: 'Оксана Володимирівна'
            },
            {
              id: 2,
              name: 'Іван Петрович'
            },
            {
              id: 3,
              name: 'Марія Іванівна'
            },
            {
              id: 4,
              name: 'Микита Олександрович'
            },
            {
              id: 5,
              name: 'Валерія Вадимівна'
            },
            {
              id: 6,
              name: 'Лариса Василівна'
            },
            {
              id: 1,
              name: 'Юрій Семенович'
            },
        ],
    },

    getters:{
        getTeachers: (state) => state.teachers,
    }
}