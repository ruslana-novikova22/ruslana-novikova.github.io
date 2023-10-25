<!--(20 балів) На сервері зберігається список Товарів (Id, Назва,
Країна виробника, Ціна). Розробити Web сторінку, для редагування даних
товару із вказаним Id та сторінку для перегляду даних товару із вказаним
Id.
3. (10 балів) Реалізувати завдання 2 зі збереженням даних в CSV файлі.-->

<?php
$products = [
    [
        'id' => 1,
        'name' => 'Ноутбук',
        'country' => 'Китай',
        'price' => 19000
    ],
    [
        'id' => 2,
        'name' => 'Смартфон',
        'country' => 'Японія',
        'price' => 1500
    ],
    [
        'id' => 3,
        'name' => 'Монітор',
        'country' => 'США',
        'price' => 12000
    ],
    [
        'id' => 4,
        'name' => 'Клавіатура',
        'country' => 'Корея',
        'price' => 1800
    ],
    [
        'id' => 5,
        'name' => 'Планшет',
        'country' => 'Канада',
        'price' => 600
    ],
];

$file_name = 'product.json';

$get_json_data = file_get_contents($file_name);
$products = json_decode($get_json_data, true);

if (isset($_POST['edit'])) {
    $id_exists = false;

    foreach ($products as $index => $product) {
        if ($product['id'] == $_POST['id']) {
            $id_exists = true;

            break;
        }
    }

    if (!$id_exists) {

        $products[] = [
            'id' => isset($_POST['id']) ? $_POST['id'] : '',
            'name' => isset($_POST['name']) ? $_POST['name'] : '',
            'country' => isset($_POST['country']) ? $_POST['country'] : '',
            'price' => isset($_POST['price']) ? $_POST['price'] : '',

        ];
    } else {
        echo "<h1>Error! Project with this code already exists</h1>";
    }
}

if (isset($_POST['edit'])) {
    foreach ($products as $index => $product) {
        if ($products['id'] == $_POST['id']) {
            $products[$index] = [
                'id' => isset($_POST['id']) ? $_POST['id'] : '',
                'name' => isset($_POST['name']) ? $_POST['name'] : '',
                'country' => isset($_POST['country']) ? $_POST['country'] : '',
                'price' => isset($_POST['price']) ? $_POST['price'] : '',
            ];
            break;
        }
    }
}
$convert_json_data = json_encode($products);
file_put_contents($file_name, $convert_json_data);


include './templates/table.phtml';
include './templates/edit.phtml';