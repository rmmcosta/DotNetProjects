using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using System.Net;
using System.IO;

using OutSystems.HubEdition.RuntimePlatform;
using OutSystems.RuntimePublic.Db;

namespace OutSystems.NssParallelExecution {

	public class CssParallelExecution: IssParallelExecution {

        public static RCResponseRecord ProcessRequest(RCRequestRecord recRequest)
        {
            RCResponseRecord recResponse = new RCResponseRecord();
            try
            {
                string url = recRequest.ssSTRequest.ssUrl;

                if (recRequest.ssSTRequest.ssURLParameters.Count > 0)
                {
                    url += "?";

                    recRequest.ssSTRequest.ssURLParameters.GetEnumerator().Reset();

                    foreach (RCParameterRecord parameter in recRequest.ssSTRequest.ssURLParameters)
                    {
                        url += string.Format("{0}={1}&", parameter.ssSTParameter.ssName, parameter.ssSTParameter.ssValue);
                    }
                }

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

                request.Timeout = recRequest.ssSTRequest.ssTimeout == 0 ? 100000 : recRequest.ssSTRequest.ssTimeout;
                request.Method = recRequest.ssSTRequest.ssMethod;
                request.AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;

                if (recRequest.ssSTRequest.ssHeaders.Count > 0)
                {
                    url += "?";

                    recRequest.ssSTRequest.ssHeaders.GetEnumerator().Reset();

                    foreach (RCParameterRecord parameter in recRequest.ssSTRequest.ssHeaders)
                    {
                        request.Headers.Add(parameter.ssSTParameter.ssName, parameter.ssSTParameter.ssValue);
                    }
                }


                if (!String.IsNullOrEmpty(recRequest.ssSTRequest.ssBody))
                {
                    request.ContentType = "application/json; charset=utf-8";
                    using (StreamWriter sw = new StreamWriter(request.GetRequestStream()))
                    {
                        sw.Write(recRequest.ssSTRequest.ssBody);
                    }
                }

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                string content = string.Empty;
                using (Stream stream = response.GetResponseStream())
                {
                    using (StreamReader sr = new StreamReader(stream))
                    {
                        content = sr.ReadToEnd();
                    }
                }

                response.Close();

                recResponse.ssSTResponse.ssStatusCode = response.StatusCode.ToString();
                recResponse.ssSTResponse.ssBody = content;
            }
            catch (Exception ex)
            {
                recResponse.ssSTResponse.ssStatusCode = "ERROR";
                recResponse.ssSTResponse.ssBody = ex.Message;

            }

            return recResponse;

        }

		/// <summary>
		/// 
		/// </summary>
		/// <param name="ssRequests"></param>
		/// <param name="ssResponses"></param>
		public void MssParallelRequest(RLRequestRecordList ssRequests, out RLResponseRecordList ssResponses) {
			ssResponses = new RLResponseRecordList();

            List<Task<RCResponseRecord>> taskList = new List<Task<RCResponseRecord>>();

            foreach (RCRequestRecord recRequest in ssRequests) 
            {
                taskList.Add(Task.Factory.StartNew(() => ProcessRequest(recRequest)));
            }

            Task.WaitAll(taskList.ToArray());

            foreach(var task in taskList)
            {
                ssResponses.Append((RCResponseRecord)task.Result);
            }

		} // MssParallelRequest


	} // CssParallelExecution

} // OutSystems.NssParallelExecution