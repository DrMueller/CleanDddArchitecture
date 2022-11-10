﻿namespace Mmu.CleanDddSimple.UnitTests.TestingAreas.CrossCutting.DeepCopying
{
    public class DeepCopyModel
    {
        public DeepCopyModel(DeepCopyModel? subModel, string? name, int age)
        {
            SubModel = subModel;
            Name = name;
            Age = age;
        }

        public int Age { get; }
        public string? Name { get; }
        public DeepCopyModel? SubModel { get; }
    }
}