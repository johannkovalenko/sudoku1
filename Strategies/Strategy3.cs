using System.Collections.Generic;

namespace Strategies
{
    public class Strategy3
    {
        public void Run(int[,][] blockforfield, int[,] sudokufield, List<int>[,] potential, List<int[]>[] fieldsperblock, List<int[]> IntListArr)
        {
            ///Strategy 3
            for (int i=1;i<=9;i++)
            {
                foreach (int j in new int[]{1,4,7})
                {
                    //Hori
                    IntListArr.Clear();
                    for (int m=j;m<=j+2;m++)
                    {
                        var IntList = potential[i,m];
                        if((IntList).Count == 2)
                        {
                            IntListArr.Add(new int[]{IntList[0], IntList[1]});
                        }
                    }
                    if (IntListArr.Count == 2)
                    {
                        if (IntListArr[0][0] == IntListArr[1][0] && IntListArr[0][1] == IntListArr[1][1])
                        {
                            int[] blockarr = blockforfield[i,j];
                            foreach (int[] n in fieldsperblock[blockarr[2]])
                            {
                                if (n[0] != i)
                                {
                                    var IntList2 = new List<int>(potential[n[0],n[1]]);
                                    IntList2.Remove(IntListArr[0][0]);
                                    IntList2.Remove(IntListArr[0][1]);
                                    potential[n[0],n[1]] = IntList2;   
                                }
                            }
                            for (int l = 1; l <=9; l++)
                            {
                                if (l != j && l != j+1 && l!= j+2)
                                {
                                    var IntList2 = new List<int>(potential[i,l]);
                                    IntList2.Remove(IntListArr[0][0]);
                                    IntList2.Remove(IntListArr[0][1]);
                                    potential[i,l] = IntList2;   
                                }
                            }
                        }
                    }
                    //Verti
                    IntListArr.Clear();
                    for (int m=j;m<=j+2;m++)
                    {
                        var IntList = potential[m,i];
                        if((IntList).Count == 2)
                        {
                            IntListArr.Add(new int[]{IntList[0], IntList[1]});
                        }
                    }
                    if (IntListArr.Count == 2)
                    {
                        if (IntListArr[0][0] == IntListArr[1][0] && IntListArr[0][1] == IntListArr[1][1])
                        {
                            int[] blockarr = blockforfield[j,i];
                            foreach (int[] n in fieldsperblock[blockarr[2]])
                            {
                                if (n[1] != i)
                                {
                                    var IntList2 = new List<int>(potential[n[0],n[1]]);
                                    IntList2.Remove(IntListArr[0][0]);
                                    IntList2.Remove(IntListArr[0][1]);
                                    potential[n[0],n[1]] = IntList2;   
                                }
                            }
                            for (int l = 1; l <=9; l++)
                            {
                                if (l != j && l != j+1 && l!= j+2)
                                {
                                    var IntList2 = new List<int>(potential[l,i]);
                                    IntList2.Remove(IntListArr[0][0]);
                                    IntList2.Remove(IntListArr[0][1]);
                                    potential[l,i] = IntList2;   
                                }
                            }
                        }
                    }
                }  


            }
        }
    }
}