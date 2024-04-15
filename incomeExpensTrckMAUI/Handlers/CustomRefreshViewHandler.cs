using Microsoft.Maui.Handlers;
using Microsoft.Maui.Platform;

namespace incomeExpensTrckMAUI.Handlers
{
    // Fixs the issue with the RefreshView on Android after updating to .NET 8
    public class CustomRefreshViewHandler : RefreshViewHandler
    {
        protected override void ConnectHandler(MauiSwipeRefreshLayout platformView)
        {

            int deviceOffset = platformView?.ProgressViewEndOffset ?? 0; 

            base.ConnectHandler(platformView);

            platformView?.SetProgressViewEndTarget(true, deviceOffset);
        }
    }
}