using System.Threading;
using GHIElectronics.TinyCLR.Pins;
using GHIElectronics.TinyCLR.Devices.Pwm;
using GHIElectronics.TinyCLR.Devices.Gpio;
using Mikro.Click;

namespace DC_Motor_Click {
    class Program {
        static void Main() {

            ////////// Set these to match your board //////////////
            var clickRstPin = SC20100.GpioPin.PD4;
            var clickCsPin = SC20100.GpioPin.PD3;
            var clickPwmPin = SC20100.PwmChannel.Controller2.PA15;
            var clickPwmController = SC20100.PwmChannel.Controller2.Id;

            //var ClickRstPin = SC20100.GpioPin.PD15;
            //var ClickCsPin = SC20100.GpioPin.PD14;
            //var ClickPwmPin = SC20100.PwmChannel.Controller13.PA6;
            //var ClickPwmController = SC20100.PwmChannel.Controller13.Id;
            ///////////////////////////////////////////////////////          

            var gpio = GpioController.GetDefault();
            var motor = new DCMotor(              
                gpio.OpenPin(clickRstPin),
                gpio.OpenPin(clickCsPin),
                PwmController.FromName(clickPwmController).OpenChannel(clickPwmPin));

            while (true) {
                motor.Set(90);// Forward at 90% speed
                Thread.Sleep(3000);
                motor.Set(-70);// Reverse at 70% speed
                Thread.Sleep(3000);
            }
        }
    }
}
