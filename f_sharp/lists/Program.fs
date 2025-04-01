open System
open BTree
open ChurchList
open CountSquaresInList
open CreateTuplesTask
open SortStringsTask
open TasksWithList

let readChurchList () =
    Console.WriteLine("Введите число n:")
    let n = System.Console.ReadLine() |> int

    Console.WriteLine("Ввод элементов:")
    let list = ChurchList.readList n

    Console.WriteLine("Список:")
    ChurchList.printList list
    list

// 6
let testBTree () =
    let tree = BTree.Node("1", BTree.Node("2", Nil, Nil), BTree.Node("3", Nil, Nil))
    BTree.traverse BTree.prefix tree

// 1-5, 7
let testChurchList () =
    Console.WriteLine("Введите число n:")
    let n = System.Console.ReadLine() |> int

    Console.WriteLine("Ввод элементов:")
    let list = ChurchList.readList n

    Console.WriteLine("Список:")
    ChurchList.printList list

    Console.WriteLine("Количество нечетных элементов списка: {0}", ChurchList.oddCount list)
    Console.WriteLine("Сумма четных элементов списка: {0}", ChurchList.evenSum list)
    Console.WriteLine("Минимум списка: {0}", ChurchList.minList list)
    Console.WriteLine("Самый часто встречающийся элемент: {0}", ChurchList.frequencyElement list)

// 8
let testCountSquares () = 
    let list = [1; 2; 3; 4; 9; 16]
    Console.WriteLine("Список: {0}", String.Join("; ", list))
    Console.WriteLine("Сколько элементов могут быть квадратом какого-то из элементов списка: {0}", CountSquaresInList.countSquares list)

// 9
let testCreateTuples () =
    let listA = [5; 3; 8; 1]
    let listB = [12; 3; 25; 40]
    let listC = [6; 15; 28; 10]

    Console.WriteLine("Список A: {0}", String.Join("; ", listA))
    Console.WriteLine("Список B: {0}", String.Join("; ", listB))
    Console.WriteLine("Список C: {0}", String.Join("; ", listC))

    let result = CreateTuplesTask.createTuples listA listB listC

    Console.WriteLine("Результат: {0}", String.Join("; ", result))

// 10
let testSortStrings () =
    Console.WriteLine("Введите строки (пустая строка для завершения):")
    let stringList = SortStringsTask.readStrings

    let sortedStrings = sortByLength stringList
    Console.WriteLine("Отсортированные строки:\n{0}", String.Join("\n", sortedStrings))

// 11
let testElementsBeforeLastMin () =
    let list = [3; 5; 1; 8; 7]
    ChurchList.printList list

    let result = TasksWithList.elementsBeforeLastMin list
    Console.WriteLine("Элементы, расположенные перед последним минимальным:")
    ChurchList.printList result

let testElementsBeforeLastMinList () =
    let list = [3; 5; 1; 8; 7]
    Console.WriteLine("Список: {0}", String.Join("; ", list))

    let result = TasksWithList.elementsBeforeLastMinList list
    Console.WriteLine("Элементы, расположенные перед последним минимальным: {0}", String.Join("; ", result))

// 12
let testShiftRight () =
    let list = [3; 5; 1; 8; 7]
    ChurchList.printList list

    let shiftedChurchList = TasksWithList.shiftRight list
    Console.WriteLine("Список Черча (со сдвигом):")
    ChurchList.printList shiftedChurchList

let testShiftRightList () =
    let list = [1; 2; 3; 4; 5]
    Console.WriteLine("Список: {0}", String.Join("; ", list))

    let shiftedList = TasksWithList.shiftRightList list
    Console.WriteLine("Список со сдвигом: {0}", String.Join("; ",shiftedList))

// 13
let testcontainsMaxInRange () =
    let list = [1; 5; 3; 8; 7]
    ChurchList.printList list

    Console.WriteLine("Результат: {0}", TasksWithList.containsMaxInRange list 3 8)

let testcontainsMaxInRangeList () =
    let list = [1; 5; 3; 8; 7]
    Console.WriteLine("Результат: {0}", TasksWithList.containsMaxInRangeList list 3 8)

// 14
let testEvenThenOdd () =
    let list = [1; 2; 3; 4; 5]
    ChurchList.printList list

    let result = TasksWithList.evenThenOdd list
    Console.WriteLine("Элементы сначала с четным индексом, затем с нечетным:")
    ChurchList.printList result

let testEvenThenOddList () =
    let list = [1; 2; 3; 4; 5]
    Console.WriteLine("Список: {0}", String.Join("; ", list))

    let result = TasksWithList.evenThenOddList list
    Console.WriteLine("Элементы сначала с четным индексом, затем с нечетным: {0}", String.Join("; ", result))

// 15
let testUniquePrimeDivisors () =
    let list = [6; 8; 12; 22; 23]
    ChurchList.printList list
    
    let result = TasksWithList.uniquePrimeDivisors list
    Console.WriteLine("Уникальные простые делители элементов списка:")
    ChurchList.printList result

let testUniquePrimeDivisorsList () =
    let list = [6; 8; 12; 22; 23]
    Console.WriteLine("Список: {0}", String.Join("; ", list))

    let result = TasksWithList.uniquePrimeDivisorsList list
    Console.WriteLine("Уникальные простые делители элементов списка: {0}", String.Join("; ", result))

// 16
let testSquaresOfFrequentElements () =
    let list = [6; 6; 12; 6; 23; 12; 45; 12]
    Console.WriteLine("Список:")
    ChurchList.printList list

    let squares = TasksWithList.squaresOfFrequentElements list

    Console.WriteLine("Список квадратов неотрицательных чисел < 100, встречающихся > 2 раз:")
    ChurchList.printList squares

let testSquaresOfFrequentElementsList () =
    let list = [6; 6; 12; 6; 23; 12; 45; 12]
    Console.WriteLine("Список: {0}", String.Join("; ", list))

    let squares = TasksWithList.squaresOfFrequentElementsList list
    Console.WriteLine("Список квадратов неотрицательных чисел < 100, встречающихся > 2 раз: {0}", String.Join("; ", squares))

[<EntryPoint>]
let main (argv :string[]) =
    testElementsBeforeLastMinList ()

    0