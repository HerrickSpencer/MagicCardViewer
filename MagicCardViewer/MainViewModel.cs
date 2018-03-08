using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MagicCardViewer
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged([CallerMemberName] string property = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }

        public ObservableCollectionWithRange<Cardset> CardSets { get; set; } = new ObservableCollectionWithRange<Cardset>();
        
        private Cardset selectedCardSet;
        public Cardset SelectedCardSet
        {
            get => selectedCardSet;
            set
            {
                selectedCardSet = value;
                RaisePropertyChanged();
            }
        }

        private Card selectedCard;
        public Card SelectedCard
        {
            get => selectedCard;
            set
            {
                selectedCard = value;
                RaisePropertyChanged();
            }
        }
    }
}
