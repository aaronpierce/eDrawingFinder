using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDF.UI
{
    class PartToDrawing
    {
        public static List<Matcher> Match(List<string> parts)
        {

            List<Matcher> matches = new List<Matcher>();
            foreach (string part in parts)
            {
                BatchReference.ProgressBarReference.Increment(BatchReference.ProgressBarReference.Step);
                List<DL.Drawing> result = Search.Filter(true, part, BatchReference.BatchOPCheckBoxReference.Checked, BatchReference.BatchBMCheckBoxReference.Checked);
                if (result.Count > 0)
                {
                    matches.Add(new Matcher()
                    {
                        Part = part,
                        Drawing = result[0]
                    }
                        );
                }
                else
                {
                    matches.Add(new Matcher()
                    {
                        Part = part,
                        Drawing = new DL.Drawing()
                        {
                            File = "Error; No Exact Match",
                        }
                    }
                        );
                }
            }

            return matches;
        }
    }
}
