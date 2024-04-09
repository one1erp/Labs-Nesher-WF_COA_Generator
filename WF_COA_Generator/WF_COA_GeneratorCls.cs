
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using COA_Generator;
using Common;
using LSEXT;
using LSSERVICEPROVIDERLib;
using System.Runtime.InteropServices;

namespace WF_COA_Generator
{

    [ComVisible(true)]
    [ProgId("WF_COA_Generator.WF_COA_GeneratorCls")]
    public class WF_COA_GeneratorCls : IWorkflowExtension
    {



        public void Execute(ref LSExtensionParameters Parameters)
        {

            try
            {

                INautilusServiceProvider sp = Parameters["SERVICE_PROVIDER"];

                var records = Parameters["RECORDS"];
                var sdgId = records.Fields["SDG_ID"].Value;

                MessageBox.Show(sdgId.ToString());

                var coaGenerator = new COA_Generator_Sdg();
                var sdgs = new List<string>();
                sdgs.Add(sdgId.ToString());
                coaGenerator.GenerateCOAforSDg(sdgs, sp);

            }


            catch (Exception ex)
            {

                Logger.WriteLogFile(ex);
            }


        }
    }
}
