<?php
// Асоціативний масив “Проект” (Код, автор проекту, кошторис проекту у грн.,
// оцінки проекту у трьох номінаціях (цілі числа від 1 до 5)).
// Запит проектів, кошторис яких не більше У грн., які у трьох номінаціях у сумі набрали не менше, ніж Х балів.

//1. Описати літерал нумерованого масиву із 5 -7 масивів з текстовими ключами, що містять дані про об'єкти згідно із варіантом .
//2. Вивести дані про об'єкти в таблицю.
//3. Підготувати функцію для вибору всіх елементів масиву, що відповідають запиту. Вивести їх в таблицю.
//4. Передбачити можливість передачі параметрів запиту через рядок стану (наприклад index.php?country=ukraine&min_age=18)
//5. Створити форму для додавання нового об'єкту до масиву.
//6. Створити форму редагування даних про об'єкт.
//7. Перед редагуванням здійснити валідацію даних (ПІБ не може бути порожнім рядком, заробітна плата повинна бути невід'ємним числом, тощо).

// Асоціативний масив “Проект” 
// (Код, автор проекту, кошторис проекту у грн., оцінки проекту у трьох номінаціях (цілі числа від 1 до 5)). 
// Запит проектів, кошторис яких не більше У грн., які у трьох номінаціях у сумі набрали не менше, ніж Х балів.


$projects = [
    [
        'code' => 1,
        'author' => 'Charlie Durham',
        'price' => 1199,
        'score' => [
            'score_1' => 2,
            'score_2' => 2,
            'score_3' => 5,
        ]
    ],
    [
        'code' => 2,
        'author' => 'Macy Webb',
        'price' => 6249,
        'score' => [
            'score_1' => 3,
            'score_2' => 11,
            'score_3' => 8,
        ]
    ],
    [
        'code' => 3,
        'author' => 'Dylan Deleon',
        'price' => 6534,
        'score' => [
            'score_1' => 6,
            'score_2' => 2,
            'score_3' => 9,
        ]
    ],
    [
        'code' => 4,
        'author' => 'Raja Gordon',
        'price' => 9203,
        'score' => [
            'score_1' => 7,
            'score_2' => 11,
            'score_3' => 20,
        ]
    ],
    [
        'code' => 5,
        'author' => 'Nadine Grant',
        'price' => 4667,
        'score' => [
            'score_1' => 4,
            'score_2' => 10,
            'score_3' => 5,
        ]
    ],
    [
        'code' => 6,
        'author' => 'Sumayyah Mitchell',
        'price' => 3738,
        'score' => [
            'score_1' => 5,
            'score_2' => 9,
            'score_3' => 13,
        ]
    ],
];


if (isset($_POST['add_project'])) {
    $id_exists = false;

    foreach ($projects as $index => $project) {
        if ($project['code'] == $_POST['code']) {
            $id_exists = true;

            break;
        }
    }

    if (!$id_exists) {
        $scores_string_to_array = explode(" ", $_POST['scores']);

        $projects[] = [
            'code' => $_POST['code'] ?? '',
            'author' => $_POST['author'] ?? '',
            'price' => $_POST['price'] ?? '',
            'score' => [
                'score_1' => $scores_string_to_array[0],
                'score_2' => $scores_string_to_array[1],
                'score_3' => $scores_string_to_array[2],
            ]
        ];
    } else {
        echo "<h1>Error! Project with this code already exists</h1>";
    }
}

if (isset($_POST['edit_project'])) {
    foreach ($projects as $index => $project) {
        if ($project['code'] == $_POST['code']) {
            $scores_string_to_array = explode(" ", $_POST['scores']);

            $projects[$index] = [
                'code' => $_POST['code'] ?? '',
                'author' => $_POST['author'] ?? '',
                'price' => $_POST['price'] ?? '',
                'score' => [
                    'score_1' => $scores_string_to_array[0],
                    'score_2' => $scores_string_to_array[1],
                    'score_3' => $scores_string_to_array[2],
                ]
            ];

            break;
        }
    }
}



if (isset($_GET['max_price']) || isset($_GET['min_sum_scores'])) {
    $projects = array_filter($projects, function ($element) {
        $return_flag = true;

        if (isset($_GET['max_price']) && $element['price'] >= $_GET['max_price']) {
            $return_flag = false;
        }

        $score_1 = $element['score']['score_1'];
        $score_2 = $element['score']['score_2'];
        $score_3 = $element['score']['score_3'];

        $score_sum = $score_1 + $score_2 + $score_3;

        if (isset($_GET['min_sum_scores']) && $score_sum <= $_GET['min_sum_scores']) {
            $return_flag = false;
        }

        return $return_flag;
    });
}



include './templates/project_table.phtml';
include './templates/project_form.phtml';
