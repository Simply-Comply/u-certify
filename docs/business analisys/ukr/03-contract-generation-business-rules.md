# Бізнес-правила - Етап генерації контракту

## Огляд
Етап генерації контракту створює юридично зобов'язуючі угоди між ОВС та клієнтом, визначаючи сферу сертифікації, умови та комерційні домовленості. Цей етап перетворює затверджену заявку в формальні контрактні відносини.

## Контекст домену
- **Тип етапу**: Юридична документація
- **Актори**: адміністратор контрактів, менеджер з якості (затвердження), уповноважений представник клієнта, система
- **Посилання на ISO 17021**: Пункт 9.1.3 - Угода про сертифікацію

## Бізнес-правила

### БП-КОН-001: Вибір шаблону контракту
**Правило**: Система ПОВИННА вибрати відповідний шаблон контракту на основі типу сертифікації
- **Типи шаблонів**:
  - Початкова сертифікація - один об'єкт
  - Початкова сертифікація - багато об'єктів
  - Передача сертифікації
  - Інтегрована система менеджменту (кілька стандартів)
- **Критерії вибору**: На основі результатів розгляду заявки
- **Кастомізація**: Тільки попередньо визначені змінні поля
- **Обґрунтування**: Забезпечує послідовність та юридичну відповідність

### БП-КОН-002: Обов'язкові елементи контракту
**Правило**: Кожен контракт ПОВИНЕН включати елементи, необхідні за ISO 17021
- **Необхідні розділи**:
  - Сфера сертифікації (точне формулювання)
  - Застосовний(і) стандарт(и) та версія
  - Кількість та розташування об'єктів
  - Тривалість аудиту (людино-дні)
  - Часовий план циклу сертифікації
  - Зобов'язання ОВС та клієнта
  - Умови та положення
  - Структура оплати
  - Положення про конфіденційність
  - Процес апеляцій та скарг
- **Валідація**: Система запобігає генерації без всіх елементів
- **Обґрунтування**: ISO 17021 Пункт 9.1.3 вимоги

### БП-КОН-003: Точність формулювання сфери
**Правило**: Сфера сертифікації ПОВИННА бути точно визначена
- **Вимоги**:
  - Чіткий опис включеної діяльності
  - Явне вказання виключень (якщо є)
  - Географічні межі (якщо застосовно)
  - Охоплені лінії продуктів/послуг
- **Обмеження символів**: Мінімум 100, максимум 500 символів
- **Перевірка**: Повинна відповідати переглянутій та затвердженій сфері
- **Обґрунтування**: Запобігає розширенню сфери та непорозумінням

### БП-КОН-004: Визначення програми аудиту
**Правило**: Контракт ПОВИНЕН визначати повну 3-річну програму аудиту
- **Елементи програми**:
  - Аудит Етапу 1: тривалість та орієнтовна дата
  - Аудит Етапу 2: тривалість та орієнтовна дата
  - Наглядовий аудит 1: час (протягом 12 місяців після сертифікації)
  - Наглядовий аудит 2: час (протягом 24 місяців після сертифікації)
  - Ресертифікація: час (до закінчення терміну дії)
- **Гнучкість**: Дати позначені як "орієнтовні, залежно від взаємної згоди"
- **Обґрунтування**: Встановлює чіткі очікування для циклу сертифікації

### БП-КОН-005: Специфікація фінансових умов
**Правило**: Контракт ПОВИНЕН чітко вказувати всі фінансові зобов'язання
- **Необхідні елементи**:
  - Плата за аудит Етапу 1
  - Плата за аудит Етапу 2
  - Річні наглядові збори
  - Плата за видачу сертифіката
  - Політика подорожей та витрат
  - Умови оплати (наприклад, Нетто 30)
  - Штрафи за прострочку платежу
- **Валюта**: Тільки USD (обмеження MVP)
- **Зміни**: Без змін плати протягом циклу сертифікації
- **Обґрунтування**: Прозорість та запобігання суперечкам

### БП-КОН-006: Умови скасування та відкладення
**Правило**: Контракт ПОВИНЕН визначати політики скасування/відкладення
- **Вікна скасування**:
  - >30 днів попередження: Без штрафу
  - 15-30 днів попередження: 25% штраф
  - 7-14 днів попередження: 50% штраф
  - <7 днів попередження: 100% штраф
- **Відкладення**: Максимум 2 рази за аудит, максимум 60 днів затримки
- **Форс-мажор**: Визначений список кваліфікованих подій
- **Обґрунтування**: Захищає ресурси ОВС дозволяючи гнучкість

### БП-КОН-007: Зобов'язання клієнта
**Правило**: Контракт ПОВИНЕН явно вказувати відповідальність клієнта
- **Ключові зобов'язання**:
  - Підтримувати відповідність системи менеджменту
  - Надавати доступ до всіх локацій та записів
  - Робити персонал доступним для інтерв'ю
  - Впроваджувати коригувальні дії в терміни
  - Повідомляти ОВС про значні зміни
  - Належне використання знаків сертифікації
  - Приймати свідоцькі аудити органом акредитації
- **Підтвердження**: Вимагає явного прийняття клієнтом
- **Обґрунтування**: ISO 17021 Пункт 8.3 та 9.1.3 вимоги

### БП-КОН-008: Зобов'язання ОВС
**Правило**: Контракт ПОВИНЕН вказувати зобов'язання ОВС
- **Ключові зобов'язання**:
  - Проводити аудити згідно ISO 17021
  - Підтримувати конфіденційність
  - Надавати компетентні аудиторські команди
  - Надавати своєчасні звіти
  - Приймати рішення про сертифікацію неупереджено
  - Підтримувати статус акредитації
  - Професійно розглядати скарги
- **Рівні обслуговування**: Доставка звіту протягом 10 робочих днів
- **Обґрунтування**: Збалансовані зобов'язання та якість обслуговування

### БП-КОН-009: Використання знаку сертифікації
**Правило**: Контракт ПОВИНЕН визначати правила використання знаку сертифікації
- **Права використання**:
  - Надаються лише при сертифікації
  - Обмежені сертифікованою сферою
  - Повинні відповідати керівним принципам бренду ОВС
  - Відкликаються при призупиненні/відкликанні
- **Обмеження**:
  - Без модифікації знаків
  - Без використання на продуктах
  - Без оманливого застосування
- **Моніторинг**: Клієнт погоджується на нагляд за використанням знаків
- **Обґрунтування**: Захищає цілісність схеми сертифікації

### БП-КОН-010: Положення про конфіденційність
**Правило**: Контракт ПОВИНЕН включати всеосяжні умови конфіденційності
- **Зобов'язання ОВС**:
  - Захищати всю інформацію клієнта
  - Обмежене розкриття (тільки як вимагається законом/акредитацією)
  - Сповіщення якщо вимагається розкриття
- **Винятки**:
  - Інформація вже публічна
  - Вимагається органом акредитації
  - Судовий наказ (з сповіщенням)
- **Тривалість**: Переживає припинення контракту на 5 років
- **Обґрунтування**: ISO 17021 Пункт 8.4 вимоги

### БП-КОН-011: Унікальний ідентифікатор контракту
**Правило**: Кожен контракт ПОВИНЕН мати унікальний ідентифікатор
- **Формат**: КТР-РРРР-ННННН-ВВ
  - КТР: Префікс контракту
  - РРРР: Рік
  - ННННН: Послідовний номер
  - ВВ: Версія (01 для початкової)
- **Зв'язування**: Повинен посилатися на ID заявки
- **Незмінність**: ID не може змінитися через поправки
- **Обґрунтування**: Контроль юридичних документів та простежуваність

### БП-КОН-012: Процедури внесення змін
**Правило**: Контракт ПОВИНЕН визначати процес внесення змін
- **Тригери змін**:
  - Зміни сфери
  - Додавання/видалення об'єктів
  - Оновлення версій стандартів
  - Зміни юридичної особи
- **Процес**: Письмова згода обох сторін
- **Документація**: Нова версія з відстеженням змін
- **Обґрунтування**: Підтримує дійсність контракту через зміни

### БП-КОН-013: Вирішення суперечок
**Правило**: Контракт ПОВИНЕН включати механізм вирішення суперечок
- **Шлях ескалації**:
  1. Прямі переговори (30 днів)
  2. Медіація (якщо погоджено)
  3. Арбітраж (обов'язковий)
- **Арбітраж**: Згідно національних правил арбітражу
- **Юрисдикція**: Місце реєстрації ОВС
- **Обґрунтування**: Уникає дорогих судових процесів

### БП-КОН-014: Робочий процес затвердження контракту
**Правило**: Контракти ПОВИННІ дотримуватися визначеного процесу затвердження
- **Затвердження ОВС**:
  - Сгенеровано: Адміністратором контрактів
  - Переглянуто: Менеджером з якості
  - Затверджено: Уповноваженим підписантом
- **Затвердження клієнта**: 
  - Тільки уповноваженим представником
  - Вимагається письмове прийняття
- **Часовий план**: 30 днів для прийняття клієнтом
- **Обґрунтування**: Забезпечує належну авторизацію

### БП-КОН-015: Прийняття електронного підпису
**Правило**: Контракт МОЖЕ бути виконаний електронно
- **Прийнятні методи**:
  - DocuSign або еквівалент
  - Підтвердження електронною поштою з авторизованої пошти
  - Прийняття порталу з автентифікацією
- **Вимоги**:
  - Часова мітка підпису
  - Ведення журналу IP-адрес
  - Перевірка особи
- **Юридична дійсність**: Рівна мокрому підпису
- **Обґрунтування**: Ефективність зберігаючи юридичну дійсність

## Переходи станів

### Дійсні переходи станів
- **Чернетка** → **Внутрішній розгляд** (при завершенні)
- **Внутрішній розгляд** → **Затверджено для відправки** (затвердження QM)
- **Затверджено для відправки** → **Відправлено клієнту** (передано)
- **Відправлено клієнту** → **Підписано клієнтом** (прийняття клієнта)
- **Підписано клієнтом** → **Повністю виконано** (контрпідпис ОВС)
- **Відправлено клієнту** → **Закінчився термін** (30-денний таймаут)
- **Будь-який стан** → **Скасовано** (будь-якою стороною до виконання)

### Інваріанти станів
- Контракт у "Чернетці" ПОВИНЕН мати всі обов'язкові розділи
- "Відправлені клієнту" контракти ПОВИННІ мати таймер закінчення
- "Повністю виконані" контракти ПОВИННІ мати обидва підписи та часові мітки

## Точки інтеграції

### Вхідні
- Результати розгляду заявки
- Механізм розрахунку зборів
- Система управління шаблонами

### Вихідні
- Планування аудиту Етапу 1
- Фінансова система (виставлення рахунків)
- Система управління документами
- Клієнтський портал

## Події життєвого циклу контракту

### Відстежувані події
- Контракт створено
- Внутрішній розгляд завершено
- Відправлено клієнту
- Клієнт переглянув (якщо використовувався портал)
- Клієнт підписав
- ОВС контрпідписала
- Внесено поправки
- Контракт закінчився/скасовано

### Сповіщення
- Клієнт: Контракт готовий для розгляду
- Клієнт: Нагадування на 7, 14, 21 дні
- ОВС: Клієнт підписав
- Обидві сторони: Підтвердження повного виконання

## Обмеження продуктивності

- Генерація контракту: < 30 секунд
- Вибір шаблону: < 2 секунд
- Рендеринг PDF: < 10 секунд
- Електронний підпис: < 5 хвилин

## Обробка помилок

### БП-КОН-ПОМ-001: Відсутній шаблон
- **Умова**: Необхідний шаблон не знайдено
- **Відповідь**: Попередити адміністратора, використати головний шаблон
- **Запобігання**: Щоденна перевірка повноти шаблонів

### БП-КОН-ПОМ-002: Збій генерації
- **Умова**: Система не може згенерувати контракт
- **Відповідь**: Поставити в чергу для повтору, сповістити адміністратора
- **Резерв**: Опція ручної генерації

### БП-КОН-ПОМ-003: Таймаут підпису
- **Умова**: Клієнт не підписує протягом 30 днів
- **Відповідь**: Автоматично закінчити термін контракту, сповістити обидві сторони
- **Відновлення**: Вимагає нової генерації контракту

## Міркування безпеки

- Доступ до контракту обмежений сторонами + уповноваженим персоналом ОВС
- Всі PDF контракти зашифровані в спокої
- Водяні знаки для чернеткових версій
- Аудиторський слід для всіх доступів та змін
- Безпечна передача (зашифрована пошта/портал)

## Обмеження MVP

- Один набір шаблонів контракту (без UI кастомізації)
- Тільки англійська мова
- Одна валюта (USD)
- Базовий електронний підпис (без просунутої інтеграції)
- Тільки стандартні умови (без відстеження переговорів)
- Без автоматизованих розрахунків цін

---

*Версія документа: 1.0*
*Останнє оновлення: 2025-05-31*
*Відповідність ISO 17021-1:2015 перевірено*