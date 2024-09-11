namespace TestsTarea
{
    [TestClass]
    public class DoublyLinkedListTests
    {

        [TestMethod]
        public void GetMiddleTest()
        {
            int[][] testArrays = new int[][]
            {
                new int[] { 1, 3, 5, 7, 9 },
                new int[] { 2, 4, 6, 8, 10 },
                new int[] { 7, 8, 9, 10 },
                new int[] { 1 },
                new int[] {1, 2 }
            };

            int[] expected = new int[] { 5, 6, 9, 1, 2 };

            for (int i = 0; i < testArrays.Length; i++)
            {
                DoublyLinkedList<int> list = new DoublyLinkedList<int>();
                foreach (int item in testArrays[i])
                {
                    list.Insert(item);
                }

                Assert.AreEqual(expected[i], IList.GetMiddle(list));
            }

            // Expect errors
            DoublyLinkedList<int> emptyList = new DoublyLinkedList<int>();
            Assert.ThrowsException<InvalidOperationException>(() => IList.GetMiddle(emptyList));

            DoublyLinkedList<int> nullList = null;
            Assert.ThrowsException<NullReferenceException>(() => IList.GetMiddle(nullList));
        }

        [TestMethod]
        public void TestInverseLists()
        {
            int[][] testArrays = new int[][]
            {
                new int[] { 1, 3, 5, 7, 9 },
                new int[] { 2, 4, 6, 8, 10 },
                new int[] { 7, 8, 9, 10},
                new int[] {2}
            };

            int[][] expected = new int[][]
            {
                new int[] { 9, 7, 5, 3, 1 },
                new int[] { 10, 8, 6, 4, 2 },
                new int[] { 10, 9, 8, 7 },
                new int[] { 2 }
            };

            for (int i = 0; i < testArrays.Length; i++)
            {
                DoublyLinkedList<int> list = new DoublyLinkedList<int>();
                foreach (int item in testArrays[i])
                {
                    list.Insert(item);
                }

                DoublyLinkedList<int> inverseList = IList.Invert(list);

                Node<int> current = inverseList.Head;
                int j = 0;
                while (current != null)
                {
                    Assert.AreEqual(expected[i][j], current.Value);
                    current = current.Next;
                    j++;
                }
            }

            // Expect errors on null and empty list
            DoublyLinkedList<int> emptyList = new DoublyLinkedList<int>();
            Assert.ThrowsException<InvalidOperationException>(() => IList.Invert(emptyList));

            DoublyLinkedList<int> nullList = null;
            Assert.ThrowsException<NullReferenceException>(() => IList.Invert(nullList));

        }
            [TestMethod]
        public void TestMergeSort()
        {
            // Test array of arrays
            int[][] testArraysA = new int[][]
            {
                new int[] { 1, 3, 5, 7, 9 },
                new int[] { 2, 4, 6, 8, 10 },
                new int[] { 7, 8, 9, 10}
            };

            // Test array of arrays
            int[][] testArraysB = new int[][]
            {
                new int[] { 2, 4, 8, 10 },
                new int[] { 1, 5, 7, 9 },
                new int[] { 1, 2, 3, 4, 5 }
            };

            int[][] expectedAscending = new int[][] {
                new int[] { 1, 2, 3, 4, 5, 7, 8, 9, 10 },
                new int[] { 1, 2, 4, 5, 6, 7, 8, 9, 10 },
                new int[] { 1, 2, 3, 4, 5, 7, 8, 9, 10 }
            };

            int[][] expectedDescending = new int[][] {
                new int[] { 10, 9, 8, 7, 5, 4, 3, 2, 1 },
                new int[] { 10, 9, 8, 7, 6, 5, 4, 2, 1 },
                new int[] { 10, 9, 8, 7, 5, 4, 3, 2, 1 }
            };

            for (int i = 0; i < testArraysA.Length; i++)
            {
                // Tests every single test arrays
                DoublyLinkedList<int> listA = new DoublyLinkedList<int>();
                DoublyLinkedList<int> listB = new DoublyLinkedList<int>();

                foreach (int item in testArraysA[i])
                {
                    listA.Insert(item);
                }

                foreach (int item in testArraysB[i])
                {
                    listB.Insert(item);
                }

                DoublyLinkedList<int> listC = IList.MergeSort(listA, listB, IList.SortDirection.Ascending);
                
                
                DoublyLinkedList<int> InverseListA = IList.Invert(listA);
                DoublyLinkedList<int> InverseListB = IList.Invert(listB);

                DoublyLinkedList<int> listD = IList.MergeSort(InverseListA, InverseListB, IList.SortDirection.Descending);

                // Test ascending
                Node<int> current = listC.Head;
                int j = 0;
                while (current != null)
                {
                    Assert.AreEqual(expectedAscending[i][j], current.Value);
                    current = current.Next;
                    j++;
                }

                // Test descending
                current = listD.Head;
                j = 0;
                listD.Print();
                while (current != null) {
                    Assert.AreEqual(expectedDescending[i][j], current.Value);
                    current = current.Next;
                    j++;
                }

                // Expect errors on null and empty list
                DoublyLinkedList<int> emptyList = new DoublyLinkedList<int>();
                Assert.ThrowsException<InvalidOperationException>(() => IList.MergeSort(emptyList, emptyList, IList.SortDirection.Ascending));

                DoublyLinkedList<int> nullList = null;
                Assert.ThrowsException<NullReferenceException>(() => IList.MergeSort(nullList, nullList, IList.SortDirection.Ascending));

                // Expect errors when one of the lists is empty
                Assert.ThrowsException<InvalidOperationException>(() => IList.MergeSort(listA, emptyList, IList.SortDirection.Ascending));
                Assert.ThrowsException<InvalidOperationException>(() => IList.MergeSort(emptyList, listB, IList.SortDirection.Ascending));

            }
        }
    }
}