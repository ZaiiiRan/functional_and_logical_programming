open System
open BTree
open ChurchList
open CountSquaresInList
open CreateTuplesTask
open SortStringsTask
open TasksWithList

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

let testCountSquares () = 
    let list = [1; 2; 3; 4; 9; 16]
    Console.WriteLine("Список: {0}", String.Join("; ", list))
    Console.WriteLine("Сколько элементов могут быть квадратом какого-то из элементов списка: {0}", CountSquaresInList.countSquares list)

let testCreateTuples () =
    let listA = [5; 3; 8; 1]
    let listB = [12; 3; 25; 40]
    let listC = [6; 15; 28; 10]

    Console.WriteLine("Список A: {0}", String.Join("; ", listA))
    Console.WriteLine("Список B: {0}", String.Join("; ", listB))
    Console.WriteLine("Список C: {0}", String.Join("; ", listC))

    let result = CreateTuplesTask.createTuples listA listB listC

    Console.WriteLine("Результат: {0}", String.Join("; ", result))

let testSortStrings () =
    Console.WriteLine("Введите строки (пустая строка для завершения):")
    let stringList = SortStringsTask.readStrings

    let sortedStrings = sortByLength stringList
    Console.WriteLine("Отсортированные строки:\n{0}", String.Join("\n", sortedStrings))

let testBTree () =
    let tree = BTree.Node("1", BTree.Node("2", Nil, Nil), BTree.Node("3", Nil, Nil))
    BTree.traverse BTree.prefix tree

let readChurchList () =
    Console.WriteLine("Введите число n:")
    let n = System.Console.ReadLine() |> int

    Console.WriteLine("Ввод элементов:")
    let list = ChurchList.readList n

    Console.WriteLine("Список:")
    ChurchList.printList list
    list

let testShiftRight () =
    let chList = readChurchList()

    let shiftedChurchList = TasksWithList.shiftRight chList
    Console.WriteLine("Список Черча (со сдвигом):")
    ChurchList.printList shiftedChurchList

let testShiftRightList () =
    let list = [1; 2; 3; 4; 5]
    Console.WriteLine("Список: {0}", String.Join("; ", list))

    let shiftedList = TasksWithList.shiftRightList list
    Console.WriteLine("Список со сдвигом: {0}", String.Join("; ",shiftedList))

let testcontainsMaxInRange () =
    let chList = readChurchList()
    Console.WriteLine("Результат: {0}", TasksWithList.containsMaxInRange chList 3 8)

let testcontainsMaxInRangeList () =
    let list = [1; 5; 3; 8; 7]
    Console.WriteLine("Результат: {0}", TasksWithList.containsMaxInRangeList list 3 8)

[<EntryPoint>]
let main (argv :string[]) =
    testcontainsMaxInRangeList ()

    0