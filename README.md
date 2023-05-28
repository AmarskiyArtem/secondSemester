## Homeworks and tests for C# course by [Yurii Litvinov](https://github.com/yurii-litvinov). SPbU, 2 semester

|Homeworks |
|--------- |
|[Homework 1](#homework-1)|
|[Homework 2](#homework-2)|
|[Homework 3](#homework-3)|
|[Homework 4](#homework-4)|
|[Homework 5](#homework-5)|
|[Homework 6](#homework-6)|
|[Homework 7](#homework-7)|
|[Homework 8](#homework-8)|

### Homework 1
#### Task 1 `Сортировка`
Отсортировать массив какой-либо из квадратичных сортировок. 
[Решение](https://github.com/AmarskiyArtem/secondSemester/tree/main/homeworks/hw1/insertionSort)
#### Task 2 `Барроуз-Уилер`
Реализовать преобразование Барроуза-Уилера. На вход подаётся строка, на выходе должна получиться строка, преобразованная Барроузом-Уилером, и позиция конца строки в результате преобразования. Реализовать также и обратное преобразование, принимающее преобразованную строку и позицию, и возвращающую исходную строку. Проверить, что исходная строка действительно восстанавливается.
* +1 балл за решение, где в прямом преобразовании не строится явно таблица вращений строк;
* +1 балл за решение, где в обратном преобразовании используется построение циклической перестановки, без явного построения таблицы.

[Решение на 2 дополнительных балла](https://github.com/AmarskiyArtem/secondSemester/tree/main/homeworks/hw1/BWT)
### Homework 2
#### Task 1 `Стековый калькулятор`
Реализовать стековый калькулятор (класс, реализующий выполнение операций +, -, *, / над арифметическим выражением в виде строки в постфиксной записи). Строка уже дана в обратной польской записи (например, `1 2 3 + *`). Стек реализовать двумя способами (например, массивом или списком) в двух разных классах на основе одного интерфейса. Стековый калькулятор должен знать только про интерфейс стека (то есть вообще в коде класса «Стековый калькулятор» не должно быть ни одного упоминания конкретных реализаций стека, даже если очень хочется). Числа и арифметические знаки разделены пробелами, числа только целые (но могут быть знаковыми, и уж точно не только из одной цифры, используйте `int.Parse` или `int.TryParse`). В результате должно получаться число — результат вычислений. Результат может быть дробным. При попытке деления на 0 должна выдаваться ошибка и программа должна корректно заканчивать работу. 
[Решение](https://github.com/AmarskiyArtem/secondSemester/tree/main/homeworks/hw2/stackCalculator)
#### Task 2 `Бор`
Реализовать в виде класса структуру данных "Бор"

Должны быть поддержаны следующие методы:
* `bool Add(string element)` (возвращает true, если такой строки ещё не было, работает за O(|element|))
* `bool Contains(string element)` (работает за O(|element|))
* `bool Remove(string element)` (возвращает true, если элемент реально был в дереве, работает за O(|element|))
* `int HowManyStartsWithPrefix`(String prefix) (работает за O(|prefix|))

И свойство
* `int Size` (работает за O(1))

[Решение](https://github.com/AmarskiyArtem/secondSemester/tree/main/homeworks/hw2/Trie)
### Homework 3
#### Task 1 `LZW`

На основе структуры данных "Бор" из д/з 2 (возможно, её придётся модифицировать для поддержки посимвольного добавления) реализовать алгоритм Лемпеля — Зива — Уэлча. Требуется написать консольное приложение, которое в качестве аргумента командной строки принимает путь к файлу, который надо сжать или разжать, и ключ `-c`, означающий, что файл надо сжать, или `-u`, означающий, что надо разжать. В качестве результата должен создаваться новый файл:

если выполняется сжатие, файл именуется как `<имя изначального файла>.zipped`.
если выполняется разжатие, расширение `.zipped` отбрасывается.
Вы вправе в сжатом файле хранить любую дополнительную информацию. Обратите внимание, что сжиматься могут не только тексты, но и бинарные файлы — для тестирования будет сжат/разжат .exe-файл и запущен после разжатия.

Программа после сжатия должна печатать коэффициент сжатия на консоль.

Применение преобразования Барроуза-Уилера из задания 1 и измерение его влияния на коэффициент сжатия (то есть сколько без него/сколько с ним на нескольких достаточно больших тестах) принесёт вам один дополнительный балл.

Использование кодовых последовательностей переменной длины принесёт ещё один балл.

[Решение на 2 дополнительных балла]

### Homework 4
#### Task 1 `Дерево разбора`
Решить задачу о вычислении выражения по дереву разбора из прошлого семестра. Реализовать иерархию классов, описывающих дерево разбора, используя их, реализовать класс, вычисляющий значение выражения по дереву. Классы, представляющие операнды и операторы, должны сами уметь себя вычислять и печатать. Входной файл может быть некорректен, необходимо использовать исключения для сигнализации об ошибках (и тестировать, что они действительно бросаются).

Исходное условие:

`По дереву разбора арифметического выражения вычислить его значение. Дерево разбора хранится в файле в виде (<операция> <операнд1> <операнд2>), где <операнд1> и <операнд2> сами могут быть деревьями, либо числами. Например, выражение (1 + 1) * 2 представляется в виде (* (+ 1 1) 2). Должны поддерживаться операции +, -, *, / и целые числа в качестве аргументов. Требуется построить дерево в явном виде, распечатать его (не обязательно так же, как в файле), и посчитать значение выражения обходом дерева. Пример — по входному файлу (* (+ 1 1) 2) может печататься ( * ( + 1 1 ) 2 ) и выводиться 4.`

#### Task 2 `UniqueList`
Реализовать класс "Список" с методами добавления, удаления и изменения элемента по позиции, и, унаследовавшись от него, реализовать класс UniqueList, который не содержит повторяющихся значений. Реализовать классы исключений, которые генерируются при попытке добавления в такой список уже существующего или при попытке удаления несуществующего элемента. Тесты не должны содержать раскопированного кода.

### Homework 5 
#### Task `Роутеры`
Есть участок сети, состоящий из роутеров, связанных Ethernet-соединениями. Поскольку разные куски этой сети администрируют разные организации, у сети отсутствует единая архитектура, что часто приводит к избыточным соединениям между роутерами, либо наоборот, изоляции участков сети. Современные сетевые протоколы устроены так, что избыточные соединения почти столь же опасны, как и их отсутствие — если роутер не знает маршрута до целевого узла, он рассылает пакеты по всем портам, кроме того, откуда пакет пришёл, в надежде, что кто-то из роутеров-адресатов сможет его доставить. Поэтому не исключена ситуация, когда пакеты начинают ходить по кругу до тех пор, пока не исчерпается их время жизни (Time To Live, TTL), что приводит к лавине дублирующихся пакетов, нагружает сеть и снижает общую производительность.

Ваша задача — написать консольное приложение, которое по данной топологии сети генерирует конфигурацию для каждого роутера и проверяет, что все роутеры достижимы. Топология задана в файле в виде списка роутеров и того, к каким другим роутерам они подключены каналами какой пропускной способности, например,

1: 2 (10), 3 (5)
2: 3 (1)
задаёт сеть из трёх роутеров, где первый связан со вторым и третьим, второй с первым и третьим, третий с первым и вторым. Причём канал между первым и вторым имеет в десять раз большую пропускную способность, чем между вторым и третьим. Вы должны вывести в файл аналогичную таблицу, где оставлены только те соединения, которые необходимы для обеспечения связности сети, без циклов, например,

1: 2 (10), 3 (5)
Причём конфигурация должна быть в каком-то смысле оптимальной: сумма пропускных способностей всех каналов в сети должна быть максимальной.

Если построить такую таблицу невозможно (то есть сеть изначально была не связной), программа должна вывести в поток ошибок (обратите внимание, не в файл и не совсем на консоль) сообщение, что сеть не связна, и завершить работу с ненулевым кодом возврата. Пути до входного и выходного файлов должны приниматься в качестве параметров.

### Homework 6
#### Task 1 `Map, Filter, Fold`
Реализовать функции Map, Filter и Fold:
Map принимает список и функцию, преобразующую элемент списка. Возвращаться должен список, полученный применением переданной функции к каждому элементу переданного списка. Например, `Map(new List<int>() {1, 2, 3}, x => x * 2)` должен возвращать список `[2; 4; 6]`.

Filter принимает список и функцию, возвращающую булевое значение по элементу списка. Возвращаться должен список, составленный из тех элементов переданного списка, для которых переданная функция вернула true.

Fold принимает список, начальное значение и функцию, которая берёт текущее накопленное значение и текущий элемент списка, и возвращает следующее накопленное значение. Сама Fold возвращает накопленное значение, получившееся после всего прохода списка. Например, `Fold(new List<int>() {1, 2, 3}, 1, (acc, elem) => acc * elem)` работала бы так: сначала в acc клался бы 1, потом умножался бы на 1, потом результат (1) умножался бы на 2, потом результат (2) умножался бы на 3, потом результат (6) возвращался бы в качестве ответа.

#### Task 2 `Игра`
На базе класса, генерирующего события по нажатию на клавиши управления курсором (EventLoop с пары), реализовать консольное приложение, позволяющее управлять персонажем, перемещающимся по карте. Карта состоит из свободного пространства и стен, и должна грузиться из файла. Приложение должно отображать карту и персонажа (символом @) в окне консоли, и позволять персонажу перемещаться по карте, реагируя на клавиши управления курсором. Будут полезны свойства `Console.CursorLeft` и `Console.CursorTop`. Каждый раз перерисовывать всю карту нельзя.
Обратите внимание, для данной задачи, как и для остальных, обязательны юнит-тесты, однако использовать функции управления устройством "Консоль" (такие как `Console.CursorLeft` и `Console.CursorTop`) из юнит-тестов не получится. Подумайте, как применить знания про лямбда-функции, чтобы тесты не пытались делать то, чего делать не могут, но в "боевом" режиме всё работало.

### Homework 7
#### Task `Калькулятор`
Написать калькулятор с пользовательским интерфейсом (по примеру стандартного калькулятора вашей любимой операционной системы). Калькулятор должен вычислять операторы немедленно, то есть если пользователь нажимает «7», «+», «3», «+», на экране должно отобразиться «10». Ввод кнопочный, то есть разбор и прямое редактирование выражения делать не надо (соответственно, скобки, приоритет операций и т.п. калькулятор не должен поддерживать). Рекомендуется вспомнить про конечные автоматы для упрощения формализации вещей в духе «если оператор нажат первый раз, ждём второй операнд, если второй операнд уже есть, печатаем ответ и запоминаем оператор».
Юнит-тесты здесь обязательны на всю функциональность, не связанную непосредственно со взаимодействием с пользователем, поэтому стоит сразу реализовывать калькулятор правильно — тонкий и глупый слой пользовательского интерфейса и отдельно класс с бизнес-логикой, который даже не знает про существование GUI.

Использование data binding для отображения результатов вычисления принесёт вам один дополнительный балл сверх максимума за эту задачу (всего 6 баллов, но с правильным data binding можно получить 7).


### Homework 8
#### Task `Skip list`
Реализовать генерик-коллекцию на базе списка с пропусками. При этом коллекция должна реализовывать интерфейс System.Collections.Generic.IList<T>. Надо следовать всем правилам реализации структуры данных в библиотеке:

* проверять на корректность все аргументы всех public-методов и свойств, бросать подходящие исключения;
* реализовать инвалидацию итератора при изменении коллекции;
* разобраться, что за свойство IsReadOnly;
* разобраться с IComparable<T>;
* можно использовать System.Collections.Generic.List<T> как пример.

При этом, как обычно, нужны юнит-тесты, в которых надо не забыть проверить, что по списку можно ходить foreach.

## License
Distributed under the Apache2.0 License. See [`LICENSE.txt`](https://github.com/AmarskiyArtem/secondSemester/blob/main/LICENSE) for more information.
