using Moq;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Http;


namespace Strado.InVento.Tests.Extenstions
{
    public static class ControllerExtentions
    {
        public static void MockCurrentUser(this Controller controller, string userid, string username)
        {
            var identity = new GenericIdentity(username);
            identity.AddClaim
                (new Claim("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name", username));
            identity.AddClaim
               (new Claim("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier", userid));

            var principal = new GenericPrincipal(identity, null);
            //**********************************//

            //var mockHttpContext = new Mock<HttpContextBase>();
            //mockHttpContext.SetupGet(c => c.User).Returns(principal);

            //var mockControllerContext = new Mock<ControllerContext>();
            //mockControllerContext.SetupGet(c => c.HttpContext).Returns(mockHttpContext.Object);

            //controller.ControllerContext = mockControllerContext.Object;

            //**********************************//

            controller.ControllerContext = Mock.Of<ControllerContext>(ctx =>
              ctx.HttpContext == Mock.Of<HttpContextBase>(http =>
                http.User == principal));

        }
    }
}
