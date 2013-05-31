// <copyright file="Chef.cs" company="MyCompany">
//     Copyright MyCompany. All rights reserved.
// </copyright>
namespace StraightLineCode
{
    using System;

    /// <summary>
    /// This class represents a chef and can cook with certain ingredients.
    /// </summary>
    public class Chef
    {
        /// <summary>
        /// Cooks with potato and carrot.
        /// </summary>
        public void Cook()
        {
            Bowl bowl = this.GetBowl();

            Potato potato = this.GetPotato();
            Carrot carrot = this.GetCarrot();
            
            this.Peel(potato);
            this.Peel(carrot);

            this.Cut(potato);
            this.Cut(carrot);

            bowl.Add(potato);
            bowl.Add(carrot);
        }

        /// <summary>
        /// Gets a new bowl.
        /// </summary>
        /// <returns>Returns bowl.</returns>
        private Bowl GetBowl()
        {
            // TODO: Not implemented
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets a new potato.
        /// </summary>
        /// <returns>Returns potato.</returns>
        private Potato GetPotato()
        {
            // TODO: Not implemented
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets new carrot.
        /// </summary>
        /// <returns>Returns carrot.</returns>
        private Carrot GetCarrot()
        {
            // TODO: Not implemented
            throw new NotImplementedException();
        }

        /// <summary>
        /// This method peels a carrot.
        /// </summary>
        /// <param name="carrot">The carrot to be peeled.</param>
        private void Peel(Carrot carrot)
        {
            // TODO: Not implemented
            throw new NotImplementedException();
        }

        /// <summary>
        /// This method peels a potato.
        /// </summary>
        /// <param name="potato">The potato to be peeled.</param>
        private void Peel(Potato potato)
        {
            // TODO: Not implemented
            throw new NotImplementedException();
        }

        /// <summary>
        /// This method cuts a potato.
        /// </summary>
        /// <param name="potato">The potato to be cut.</param>
        private void Cut(Potato potato)
        {
            // TODO: Not implemented
            throw new NotImplementedException();
        }

        /// <summary>
        /// This method cuts a carrot.
        /// </summary>
        /// <param name="carrot">The carrot to be cut.</param>
        private void Cut(Carrot carrot)
        {
            // TODO: Not implemented
            throw new NotImplementedException();
        }
    }
}