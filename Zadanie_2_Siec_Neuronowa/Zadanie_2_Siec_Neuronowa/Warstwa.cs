﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie_2_Siec_Neuronowa
{
    public class Warstwa
    {
        public enum RodzajWarstwy
        {
            Ukryta,
            Wyjsciowa
        }

        public int Id { get; set; }

        public int IloscNeuronow { get; set; }

        public List<Neuron> Neurony { get; set; }

        public RodzajWarstwy rodzajWarstwy { get; set; }

        public Warstwa PoprzedniaWarstwa { get; set; }

        public Warstwa NastepnaWarstwa { get; set; }

        public Warstwa(int id, int iloscNeurnow)
        {
            Id = id;
            IloscNeuronow = iloscNeurnow;
            Neurony = new List<Neuron>();
        }

        public Warstwa()
        {

        }

        public void DodajNeuron(Neuron neuron)
        {
            Neurony.Add(neuron);
        }

        public List<double> SumujNeurony(List<double> dane)
        {
            List<double> wynik = new List<double>();
            foreach (var item in Neurony)
            {
                double suma = item.ObliczWyjscie(dane);
                wynik.Add(suma);
            }
            return wynik;
        }
    }
}
