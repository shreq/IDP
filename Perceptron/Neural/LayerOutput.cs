﻿using static Perceptron.Utils;

namespace Perceptron.Neural
{
    class LayerOutput : LayerBase
    {
        public LayerOutput(int layerSize, int inputs, bool biasEnabled) : base(layerSize, inputs, biasEnabled) { }

        public override float[] GetErrors(float[] targetOutputs)
        {
            var errors = new float[Neurons.Length];
            for (int i = 0; i < Neurons.Length; i++)
            {
                errors[i] = SigmoidDerivativeFunc(Neurons[i].Sum) * (targetOutputs[i] - Neurons[i].Output);
            }
            return errors;
        }
    }
}
