# waste_collection_system
System wspomagający proces odbioru odpadów

Głównym zadaniem systemu jest wspomaganie procesu odbioru odpadów. Stworzone zostały elementy pozwalające optymalizować trasy przejazdu dla śmieciarek. Trasy są generowane na podstawie analizy pomiarów poziomu zapełnienia śmietników oraz danych o ich lokalizacji.

Architektura systemu bazuje na architekturze zorientowanej na usługi. System składa się z mikrousług danych, mikrousług przetwarzających, mikrousługi aplikacyjnej oraz aplikacji. Zdefiniowane zostały cztery mikrousługi danych: Śmietniki, Pomiary, Śmieciarki, Trasy. Dodatkowo, mikrousługa przetwarzająca Trasowanie oraz mikrousługa przetwarzająca Czujniki wspomagają procesy zachodzące w systemie. Mikrousługa aplikacyjna Dyspozytor wspomaga aplikację Dyspozytor wykonując odpowiednie operacje oraz przekazując dane.
