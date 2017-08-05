using EmpoleeysMonitor.Lib.Model;
using System.Collections.Generic;

namespace EmpoleeysMonitor.Lib.Monitor
{
    /// <summary>
    /// Interfejs bazowy do klas monitorów.
    /// Każdy monitor musi implementować ten interfejs.
    /// Jeśli monitor wymaga dodatkowych parametrów wejściowych należy je dostarczyć przez konstruktor/właściwości.
    /// </summary>
    public interface IMonitor
    {
        /// <summary>
        /// Rozpoczyna monitorowanie.
        /// Powinien uruchamiać nowy wątek, aby metoda była nie-blokująca.
        /// </summary>
        void Start();

        /// <summary>
        /// Kończy monitorowanie.
        /// </summary>
        void End();

        /// <summary>
        /// Zwraca akcje powstałe od ostatniego wywołania tej metody.
        /// Powinien pobierać dane z pamięci współdzielonej między wątkami (z użyciem np. 'lock').
        /// </summary>
        /// <returns>Akcje powstałe od ostatniego wywołania tej metody.</returns>
        IList<UserAction> GetLatestUserActions();
    }
}
