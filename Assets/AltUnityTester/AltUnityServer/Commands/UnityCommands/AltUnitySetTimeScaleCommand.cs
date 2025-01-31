﻿using Altom.AltUnityDriver.Commands;

namespace Assets.AltUnityTester.AltUnityServer.Commands
{
    class AltUnitySetTimeScaleCommand : AltUnityCommand<AltUnitySetTimeScaleParams, string>
    {
        public AltUnitySetTimeScaleCommand(AltUnitySetTimeScaleParams cmdParams) : base(cmdParams)
        {
        }

        public override string Execute()
        {
            UnityEngine.Time.timeScale = CommandParams.timeScale;
            return "Ok";
        }
    }
}
