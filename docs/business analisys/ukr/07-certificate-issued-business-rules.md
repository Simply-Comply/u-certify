# Бізнес-правила - Етап видачі сертифіката

## Огляд
Етап видачі сертифіката представляє фінальний крок у процесі початкової сертифікації, де формальні сертифікати генеруються, перевіряються на якість, видаються клієнтам та реєструються в публічних базах даних. Цей етап перетворює рішення про сертифікацію в матеріальні документи, які клієнти можуть використовувати для демонстрації відповідності.

## Контекст домену
- **Тип етапу**: Генерація та розповсюдження документів
- **Актори**: адміністратор сертифікатів, рецензент якості, клієнт, система, публічний реєстр
- **Посилання на ISO 17021**: Пункт 9.5.2 - Документи сертифікації

## Бізнес-правила

### БП-ВС-001: Тригер генерації сертифіката
**Правило**: Сертифікати ПОВИННІ генеруватися тільки після позитивного рішення
- **Передумови**:
  - Рішення про сертифікацію = "Надати сертифікацію"
  - Всі незначні НВ закриті (докази переглянуті)
  - Зобов'язання з оплати виконані
  - Відсутні очікувані апеляції або скарги
- **Автоматичний тригер**: Протягом 1 робочого дня після рішення
- **Ручне перевизначення**: Тільки менеджером з якості
- **Обґрунтування**: Забезпечує виконання всіх умов перед видачею

### БП-ВС-002: Унікальний ідентифікатор сертифіката
**Правило**: Кожен сертифікат ПОВИНЕН мати унікальний ідентифікатор
- **Формат**: ОВС-СТД-РРРР-ННННН
  - ОВС: Ідентифікатор ОВС (3 літери)
  - СТД: Код стандарту (наприклад, QMS, EMS, OHS)
  - РРРР: Рік видачі
  - ННННН: Послідовний номер
- **Приклади**: 
  - УСБ-QMS-2025-00001 (ISO 9001)
  - УСБ-EMS-2025-00001 (ISO 14001)
- **Унікальність**: Забезпечується системою, без дублікатів
- **Обґрунтування**: Простежуваність та перевірка

### БП-ВС-003: Обов'язковий зміст сертифіката
**Правило**: Сертифікати ПОВИННІ містити всю необхідну інформацію
- **Необхідні елементи**:
  - Номер сертифіката (унікальний ідентифікатор)
  - Юридична назва та адреса клієнта
  - Сфера сертифікації (точне формулювання)
  - Застосовний(і) стандарт(и) з версією
  - Дата початкової сертифікації
  - Дата видачі сертифіката
  - Дата закінчення сертифіката
  - Назва та логотип ОВС
  - Логотип та номер органу акредитації
  - Уповноважені підписи (цифрові)
- **Валідація**: Система запобігає неповним сертифікатам
- **Обґрунтування**: ISO 17021 Пункт 9.5.2 вимоги

### БП-ВС-004: Точність формулювання сфери
**Правило**: Сфера сертифіката ПОВИННА точно відповідати затвердженій сфері
- **Вимоги перевірки**:
  - Дослівне співпадіння з записом рішення
  - Без додавань або модифікацій
  - Виключення чітко вказані якщо застосовно
  - Адреси об'єктів повні та точні
- **Перевірка якості**: Обов'язкова перед випуском
- **Зміни**: Вимагають нового рішення про сертифікацію
- **Обґрунтування**: Запобігає неправильному представленню сфери

### БП-ВС-005: Дати дійсності сертифіката
**Правило**: Дати сертифіката ПОВИННІ дотримуватися стандартних правил
- **Розрахунки дат**:
  - Дата початкової сертифікації: Дата позитивного рішення
  - Дата видачі: Дата генерації сертифіката
  - Дата закінчення: 3 роки з дати початкової сертифікації
  - Перевидання зберігає оригінальну початкову дату
- **Без задатування**: Дата видачі завжди поточна
- **Без продовжень**: Дата закінчення незмінна
- **Обґрунтування**: Послідовні цикли сертифікації

### БП-ВС-006: Обробка багатооб'єктних сертифікатів
**Правило**: Багатооб'єктні сертифікати ПОВИННІ включати всі локації
- **Головний сертифікат**: Перелічує всі об'єкти в сфері
- **Додаток об'єктів**: Детальний список з:
  - Назви та адреси об'єктів
  - Діяльність на кожному об'єкті
  - Позначення центрального офісу
- **Опціонально**: Індивідуальні під-сертифікати об'єктів
- **Нумерація сторінок**: Формат "Сторінка X з Y"
- **Обґрунтування**: Повна видимість сфери

### БП-ВС-007: Багатостандартні сертифікати
**Правило**: Кілька стандартів МОЖУТЬ бути на одному сертифікаті
- **Правила комбінування**:
  - Тільки для інтегрованих систем менеджменту
  - Потрібна спільна сфера
  - Всі стандарти повинні бути сертифіковані
  - Застосовується найкоротша дата закінчення
- **Альтернатива**: Окремі сертифікати на стандарт
- **Вибір клієнта**: Якщо право на комбінований
- **Обґрунтування**: Гнучкість зберігаючи ясність

### БП-ВС-008: Мова сертифіката
**Правило**: Сертифікати ПОВИННІ видаватися визначеними мовами
- **Основна**: Англійська (обов'язково)
- **Додаткова**: Місцева мова за запитом
- **Переклад**: Потрібен професійний переклад
- **Перевірка**: Обидві версії перевірені QC
- **Юридична версія**: Англійська має перевагу
- **Примітка MVP**: Тільки англійська в Фазі 1
- **Обґрунтування**: Міжнародне визнання

### БП-ВС-009: Цифровий формат сертифіката
**Правило**: Сертифікати ПОВИННІ бути переважно цифровими
- **Вимоги формату**:
  - Формат PDF/A для архівування
  - Цифрово підписано сертифікатом
  - Захисні функції від підробки
  - Готово для друку у високій роздільності
  - Вбудовані метадані
- **Функції безпеки**:
  - Цифровий водяний знак
  - QR код для перевірки
  - Унікальний хеш документа
- **Обґрунтування**: Безпека та автентичність

### БП-ВС-010: Контроль якості сертифіката
**Правило**: Кожен сертифікат ПОВИНЕН пройти QC перед випуском
- **Чек-лист QC**:
  - Орфографія та граматика
  - Точність даних (дати, номери)
  - Точність формулювання сфери
  - Розміщення та якість логотипу
  - Дійсність цифрового підпису
  - Активні функції безпеки
- **Виконавець QC**: Відмінний від генератора
- **Докази**: Чек-лист QC зберігається
- **Обґрунтування**: Професійне забезпечення якості

### БП-ВС-011: Розповсюдження сертифікатів
**Правило**: Сертифікати ПОВИННІ розповсюджуватися безпечно
- **Методи розповсюдження**:
  - Безпечна електронна пошта (зашифрована)
  - Завантаження з клієнтського порталу
  - Рекомендована пошта (якщо запитується друкована копія)
- **Підтвердження**: Обов'язкова квитанція доставки
- **Часовий план**: Протягом 5 робочих днів після рішення
- **Контроль доступу**: Тільки уповноважений отримувач
- **Обґрунтування**: Безпечне підтвердження доставки

### БП-ВС-012: Оновлення публічного реєстру
**Правило**: Видані сертифікати ПОВИННІ бути публічно зареєстровані
- **Інформація реєстру**:
  - Номер сертифіката
  - Назва клієнта
  - Сфера сертифікації
  - Сертифікований(і) стандарт(и)
  - Дійсність з/до дат
  - Поточний статус
- **Часовий план оновлення**: Протягом 24 годин після видачі
- **Публічний доступ**: База даних з пошуком
- **Обґрунтування**: Прозорість та перевірка

### БП-ВС-013: Служба перевірки сертифікатів
**Правило**: ОВС ПОВИННА надавати перевірку сертифікатів
- **Методи перевірки**:
  - Онлайн пошук за номером сертифіката
  - Сканування QR коду
  - Служба перевірки електронною поштою/телефоном
- **Елементи відповіді**:
  - Статус дійсності
  - Підтвердження сфери
  - Дата закінчення
  - Будь-які призупинення/відкликання
- **Доступність**: 24/7 онлайн служба
- **Обґрунтування**: Боротьба з шахрайством сертифікатів

### БП-ВС-014: Друковані сертифікати
**Правило**: Фізичні сертифікати МОЖУТЬ надаватися
- **Коли надаються**:
  - Конкретний запит клієнта
  - Місцева регуляторна вимога
  - Може застосовуватися додаткова плата
- **Функції безпеки**:
  - Захищений папір
  - Голографічні елементи
  - Рельєфна печатка
  - Послідовна нумерація
- **Контроль**: Потрібне відстеження інвентарю
- **Обґрунтування**: Деякі ринки вимагають фізичні

### БП-ВС-015: Модифікації сертифікатів
**Правило**: Видані сертифікати НЕ ПОВИННІ модифікуватися
- **Заборона**: Без змін після видачі
- **Необхідні зміни**: Видати новий сертифікат
- **Контроль версій**: Новий номер версії
- **Попередня версія**: Позначена як замінена
- **Аудиторський слід**: Всі версії зберігаються
- **Обґрунтування**: Цілісність документа

### БП-ВС-016: Позначення призупинення сертифіката
**Правило**: Призупинені сертифікати ПОВИННІ бути чітко позначені
- **Дії призупинення**:
  - Статус оновлений у всіх системах
  - Публічний реєстр показує "Призупинено"
  - Клієнт сповіщений негайно
  - Не може використовувати сертифікат під час призупинення
- **Відновлення**: Видається новий сертифікат
- **Часовий план**: Негайно після рішення про призупинення
- **Обґрунтування**: Запобігання неправильному використанню

### БП-ВС-017: Процес відкликання сертифіката
**Правило**: Відкликані сертифікати ПОВИННІ бути аннульовані
- **Дії відкликання**:
  - Статус = "Відкликано" назавжди
  - Публічний реєстр оновлений
  - Клієнт повинен повернути/знищити
  - Юридичне повідомлення якщо неправильне використання продовжується
- **Незворотність**: Не може бути відновлено
- **Документація**: Причина відкликання записана
- **Обґрунтування**: Чітке припинення

### БП-ВС-018: Вимоги архіву сертифікатів
**Правило**: Всі сертифікати ПОВИННІ бути заархівовані
- **Вимоги архіву**:
  - Цифрова копія: Постійне зберігання
  - Метадані збережені
  - Індекс з пошуком
  - Резервні копії підтримуються
  - Включений аудиторський слід
- **Доступ**: Обмежений уповноваженим персоналом
- **Відновлення**: Протягом 24 годин за потреби
- **Обґрунтування**: Довгострокові записи

### БП-ВС-019: Використання знаку акредитації
**Правило**: Знаки акредитації ПОВИННІ використовуватися правильно
- **Правила використання**:
  - Тільки поточні знаки акредитації
  - Правильний розмір та розміщення
  - Включати номер акредитації
  - Дотримуватися керівних принципів AB
- **Перевірка**: Частина процесу QC
- **Оновлення**: При поновленні акредитації
- **Обґрунтування**: Відповідність акредитації

### БП-ВС-020: Тригери перевидання сертифіката
**Правило**: Сертифікати МОЖУТЬ бути перевидані з обґрунтованих причин
- **Дійсні тригери**:
  - Зміна юридичної назви
  - Зміна адреси
  - Виправлення адміністративної помилки
  - Пошкодження/втрата (запит клієнта)
- **Не дозволяються зміни**:
  - Модифікації сфери
  - Дати дійсності
  - Охоплені стандарти
- **Процес**: Вимагає авторизації
- **Обґрунтування**: Підтримання точності

## Переходи станів

### Дійсні переходи станів
- **Очікує генерації** → **У генерації** (процес розпочато)
- **У генерації** → **QC огляд** (сертифікат створено)
- **QC огляд** → **Затверджено** (QC пройшов)
- **QC огляд** → **Відхилено** (QC не пройшов, регенерувати)
- **Затверджено** → **Видано** (розповсюджено клієнту)
- **Видано** → **Призупинено** (якщо порушення)
- **Видано** → **Відкликано** (якщо припинено)
- **Призупинено** → **Перевидано** (якщо відновлено)

### Інваріанти станів
- "Видані" сертифікати ПОВИННІ бути в публічному реєстрі
- "Призупинені" сертифікати ПОВИННІ показувати дату призупинення
- "Відкликані" сертифікати ПОВИННІ показувати причину відкликання

## Точки інтеграції

### Вхідні
- Система рішень про сертифікацію
- Перевірка платежу
- База даних клієнтів

### Вихідні
- База даних публічного реєстру
- Клієнтський портал
- Планування нагляду
- Маркетинг (історії успіху)
- Фінанси (завершення)

## Показники продуктивності

### Відстежувані метрики
- Час видачі сертифіката (рішення до доставки)
- Коефіцієнт проходження QC (з першого разу)
- Своєчасність оновлення реєстру
- Використання служби перевірки
- Частота перевидання

### Індикатори якості
- Помилки сертифікатів знайдені після видачі
- Скарги клієнтів на сертифікати
- Спроби шахрайських сертифікатів
- Висновки органу акредитації

## Вимоги до аудиторського сліду

### Відстежувані події
- Генерація ініційована
- QC виконано
- Затвердження/відхилення
- Метод розповсюдження
- Підтвердження доставки
- Оновлення реєстру
- Запити перевірки
- Зміни статусу

### Зберігання даних
- Дані сертифіката: Постійно
- Журнали генерації: 5 років
- Записи розповсюдження: 3 роки
- Журнали перевірки: 1 рік

## Обробка помилок

### БП-ВС-ПОМ-001: Збій генерації
- **Умова**: Система не може згенерувати сертифікат
- **Відповідь**: Попередити адміністратора, ручний резерв
- **Вирішення**: Виправити та регенерувати
- **Вплив на клієнта**: Сповіщення про затримку

### БП-ВС-ПОМ-002: Відхилення QC
- **Умова**: Сертифікат не проходить перевірку якості
- **Відповідь**: Повернути до генерації з проблемами
- **Відстеження**: Причини відхилення QC записані
- **Запобігання**: Оновлення шаблонів

### БП-ВС-ПОМ-003: Збій розповсюдження
- **Умова**: Неможливо доставити клієнту
- **Відповідь**: Кілька спроб доставки
- **Ескалація**: Контакт менеджера рахунку
- **Альтернатива**: Доступність порталу

### БП-ВС-ПОМ-004: Збій синхронізації реєстру
- **Умова**: Оновлення публічного реєстру не вдається
- **Відповідь**: Поставити в чергу для повтору
- **Ручне перевизначення**: Якщо постійний збій
- **Моніторинг**: Щоденні звіти синхронізації

## Міркування безпеки

- Доступ до шаблонів сертифікатів контрольований
- Цифрові підписи захищені HSM
- Аудиторський слід генерації незмінний
- Зашифроване зберігання
- Зашифрований канал розповсюдження
- Заходи проти підробки
- Регулярне тестування безпеки

## Обмеження MVP

- Тільки англійська мова
- Один дизайн сертифіката
- Базовий QR код (без динамічного контенту)
- Ручний процес QC
- Електронна пошта як основне розповсюдження
- Простий публічний реєстр
- Без перевірки блокчейну
- Тільки стандартний формат PDF

---

*Версія документа: 1.0*
*Останнє оновлення: 2025-05-31*
*Відповідність ISO 17021-1:2015 перевірено*