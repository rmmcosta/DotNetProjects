using System.Collections.Generic;
using System.Reflection;
using System.Web;
using System.Web.SessionState;

namespace OutSystems.NssUltimatePDF.Session
{
    public class SessionUtils
    {

        private const string SESSION_COOKIE_REACT1 = "nr1Users";
        private const string SESSION_COOKIE_REACT2 = "nr2Users";

        private const string REACTIVE_SESSION_COOKIE_1 = "nr1Users";
        private const string REACTIVE_SESSION_COOKIE_2 = "nr2Users";

        public IEnumerable<HttpCookie[]> SessionCookies
        {
            get
            {
                HttpRequest request = HttpContext.Current.Request;

                HttpCookie[] httpCookies = new HttpCookie[2];

                HttpCookie cookie1 = request.Cookies.Get(REACTIVE_SESSION_COOKIE_1);
                HttpCookie cookie2 = request.Cookies.Get(REACTIVE_SESSION_COOKIE_2);

                httpCookies[0] = cookie1;
                httpCookies[1] = cookie2;


                yield return httpCookies;
            }
        }

        public void DowngradeToReadOnlySession()
        {
            HttpSessionState session = HttpContext.Current.Session;

            if (!session.IsReadOnly)
            {
                SessionStateModule module = GetModule(HttpContext.Current.Session);
                object lockId = GetLockId(module);

                SessionStateStoreData data = GetStoreData(module);
                GetProvider(module).SetAndReleaseItemExclusive(HttpContext.Current, session.SessionID, data, lockId, GetStateNotFound(module));

                SetReadOnly(module);
            }
        }

        private SessionStateModule GetModule(HttpSessionState session)
        {
            PropertyInfo container = session.GetType().GetProperty("Container", BindingFlags.Instance | BindingFlags.NonPublic);
            IHttpSessionState sessionContainer = (IHttpSessionState)container.GetValue(session, new object[] { });

            FieldInfo stateModule = sessionContainer.GetType().GetField("_stateModule", BindingFlags.Instance | BindingFlags.NonPublic);
            return (SessionStateModule)stateModule.GetValue(sessionContainer);
        }

        private object GetLockId(SessionStateModule module)
        {
            FieldInfo lockId = module.GetType().GetField("_rqLockId", BindingFlags.Instance | BindingFlags.NonPublic);
            return lockId.GetValue(module);
        }

        private SessionStateStoreData GetStoreData(SessionStateModule module)
        {
            FieldInfo item = module.GetType().GetField("_rqItem", BindingFlags.Instance | BindingFlags.NonPublic);
            return (SessionStateStoreData)item.GetValue(module);
        }

        private bool GetStateNotFound(SessionStateModule module)
        {
            FieldInfo stateNotFound = module.GetType().GetField("_rqSessionStateNotFound", BindingFlags.Instance | BindingFlags.NonPublic);
            return (bool)stateNotFound.GetValue(module);
        }

        private SessionStateStoreProviderBase GetProvider(SessionStateModule module)
        {
            FieldInfo store = module.GetType().GetField("_store", BindingFlags.Instance | BindingFlags.NonPublic);
            return (SessionStateStoreProviderBase)store.GetValue(module);
        }

        private void SetReadOnly(SessionStateModule module)
        {
            FieldInfo readOnly = module.GetType().GetField("_rqReadonly", BindingFlags.Instance | BindingFlags.NonPublic);
            readOnly.SetValue(module, true);
        }


    }
}
