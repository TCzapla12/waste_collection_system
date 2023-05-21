namespace PDI.DataServiceDumpsters.Logic
{
    using System.Collections.Generic;
    using System.Linq;
    using PDI.DataServiceDumpsters.Model;
    public class DumpstersDatabase : IDumpstersDatabase
    {
        private const string dumpstersJsonFilename = "dumpsters.json";

        private static readonly IList<Dumpster> Dumpsters = new List<Dumpster>();

        private static readonly object dumpstersLock = new();

        static DumpstersDatabase()
        {
            lock (DumpstersDatabase.dumpstersLock)
            {
                DumpstersDatabase.Dumpsters = DumpstersDatabaseReader.ReadDumpsters(dumpstersJsonFilename);
            }
        }
        public DumpstersDatabase()
        {
        }
        public string AddDumpster(Dumpster dumpster)
        {
            lock (DumpstersDatabase.dumpstersLock)
            {
                DumpstersDatabase.Dumpsters.Add(dumpster);

                DumpstersDatabaseWriter.WriteDumpsters(dumpstersJsonFilename, DumpstersDatabase.Dumpsters);

                return Message.GetMessage(MessageEnum.success);
            }
        }

        public string EditDumpster(Dumpster dumpster)
        {
            string searchId = dumpster.Id;

            lock (DumpstersDatabase.dumpstersLock)
            {
                for (int i = 0; i < DumpstersDatabase.Dumpsters.Count; i++)
                {
                    if (DumpstersDatabase.Dumpsters[i].Id == searchId)
                    {
                        if (DumpstersDatabase.Dumpsters[i].State == State.assigned || DumpstersDatabase.Dumpsters[i].State == State.faultAssigned)
                        {
                            return Message.GetMessage(MessageEnum.notAvailable);
                        }
                        DumpstersDatabase.Dumpsters[i] = dumpster;

                        DumpstersDatabaseWriter.WriteDumpsters(dumpstersJsonFilename, DumpstersDatabase.Dumpsters);

                        return Message.GetMessage(MessageEnum.success);
                    }
                }

            }
            return Message.GetMessage(MessageEnum.notExist);
        }
        public string ChangeDumpsterUsage(string id, int usage)
        {
            lock (DumpstersDatabase.dumpstersLock)
            {
                for (int i = 0; i < DumpstersDatabase.Dumpsters.Count; i++)
                {
                    if (DumpstersDatabase.Dumpsters[i].Id == id)
                    {
                        DumpstersDatabase.Dumpsters[i].SetUsage(usage);

                        DumpstersDatabaseWriter.WriteDumpsters(dumpstersJsonFilename, DumpstersDatabase.Dumpsters);

                        return Message.GetMessage(MessageEnum.success);
                    }
                }
            }
            return Message.GetMessage(MessageEnum.notExist);
        }
        public string ChangeDumpstersState(List<string> ids, State state)
        {
            string errorMessage = string.Empty;

            bool found = false;
            int count = 0;

            lock (DumpstersDatabase.dumpstersLock)
            {
                for (int i = 0; i < ids.Count; i++)
                {
                    for(int j = 0; j < DumpstersDatabase.Dumpsters.Count; j++)
                    {
                        if (DumpstersDatabase.Dumpsters[j].Id == ids[i])
                        {
                            count++;
                            if (DumpstersDatabase.Dumpsters[j].State == state)
                            {
                                errorMessage = Message.GetMessage(MessageEnum.sameState);
                                break;
                            }
                            else if (DumpstersDatabase.Dumpsters[j].State == State.disabled && (state == State.assigned || state == State.faultAssigned))
                            {
                                errorMessage = Message.GetMessage(MessageEnum.notAvailable);
                                break;
                            }

                            found = true;

                            DumpstersDatabase.Dumpsters[j].SetState(state);

                            break;
                        }
                    }
                }
                if(found)
                {
                    DumpstersDatabaseWriter.WriteDumpsters(dumpstersJsonFilename, DumpstersDatabase.Dumpsters);
                    if (errorMessage == string.Empty && count == ids.Count)
                    {
                        return Message.GetMessage(MessageEnum.success);
                    }
                    else
                    {
                        return Message.GetMessage(MessageEnum.warning);
                    }
                }
            }
            if(errorMessage!= string.Empty)
            {
                return errorMessage;
            }
            return Message.GetMessage(MessageEnum.notExist);
        }
        public string DeleteDumpster(string id)
        {
            lock (DumpstersDatabase.dumpstersLock)
            {
                for (int i = 0; i < DumpstersDatabase.Dumpsters.Count; i++)
                {
                    if (DumpstersDatabase.Dumpsters[i].Id == id)
                    {
                        if (DumpstersDatabase.Dumpsters[i].State == State.assigned || DumpstersDatabase.Dumpsters[i].State == State.faultAssigned)
                        {
                            return Message.GetMessage(MessageEnum.notAvailable);
                        }
                        DumpstersDatabase.Dumpsters.RemoveAt(i);

                        DumpstersDatabaseWriter.WriteDumpsters(dumpstersJsonFilename, DumpstersDatabase.Dumpsters);

                        return Message.GetMessage(MessageEnum.success);
                    }
                }

            }
            return Message.GetMessage(MessageEnum.notExist);
        }
        public Dumpster[] GetDumpsters()
        {
            lock (DumpstersDatabase.dumpstersLock)
            {
                return DumpstersDatabase.Dumpsters.ToArray();
            }
        }
        public string GetNewId()
        {
            if (DumpstersDatabase.Dumpsters.Count == 0)
            {
                return "0";
            }
            else return (int.Parse(DumpstersDatabase.Dumpsters.Last().Id) + 1).ToString();
        }

        public string EmptyDumpsters(List<string> ids)
        {
            string errorMessage = string.Empty;

            bool found = false;
            int count = 0;

            lock (DumpstersDatabase.dumpstersLock)
            {
                for (int i = 0; i < ids.Count; i++)
                {
                    for (int j = 0; j < DumpstersDatabase.Dumpsters.Count; j++)
                    {
                        if (DumpstersDatabase.Dumpsters[j].Id == ids[i])
                        {
                            count++;
                            if (DumpstersDatabase.Dumpsters[j].State == State.disabled)
                            {
                                errorMessage = Message.GetMessage(MessageEnum.notAvailable);
                                break;
                            }

                            found = true;

                            DumpstersDatabase.Dumpsters[j].SetUsage(0);

                            break;
                        }
                    }
                }
                if (found)
                {
                    DumpstersDatabaseWriter.WriteDumpsters(dumpstersJsonFilename, DumpstersDatabase.Dumpsters);
                    if (errorMessage == string.Empty && count == ids.Count)
                    {
                        return Message.GetMessage(MessageEnum.success);
                    }
                    else
                    {
                        return Message.GetMessage(MessageEnum.warning);
                    }
                }
            }
            if (errorMessage != string.Empty)
            {
                return errorMessage;
            }
            return Message.GetMessage(MessageEnum.notExist);
        }
    }
}
