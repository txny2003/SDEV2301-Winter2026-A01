namespace InheritancePolymorphism.Shapes
{
    // Interfaces are used to define properties and/or methods that an object
    // MUST have.
    public interface IPolygon
    {
        int NumberOfSides { get; }
        void CalculateAngleOfCorners();
    }
}
