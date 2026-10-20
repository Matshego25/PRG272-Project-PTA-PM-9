# PRG272 Project PTA PM 9

# Baobab Ridge Wildlife Rehabilitation Records System

Group Members: Omphemetse Matshego Mosala [603425],
               Molemo Mothelo [602818],
               Muhammad Shahzad [604086],
               Ayanda Penelope Bonongo [604996]

## How to build and run

**Requirements:** Windows, Visual Studio 2022 (or newer) with the ".NET desktop development" workload, and the .NET 8.0 SDK or newer.

1. Clone the repository:
```
   git clone https://github.com/Matshego25/PRG272-Project-PTA-PM-9.git
```
2. Open the `.slnx` file in Visual Studio.
3. Set the build configuration to **Debug** and choose **Build > Build Solution** (Ctrl+Shift+B).
4. Press **F5** to run.

The starter `animals.txt` is set to "Copy if newer", so it is copied beside the `.exe` on every build. The program reads and writes `animals.txt` and `summary.txt` in the same folder as the `.exe` (for example `bin\Debug\net8.0-windows\`). No file paths are tied to a specific computer.

## Features

- **Load on startup:** reads `animals.txt` and shows every valid record in a grid. If the file does not exist, an empty one is created.
- **Add an animal:** validated entry of ID, name, species, age and recovery score.
- **View animals:** all records shown in a grid.
- **Update an animal:** edit a record (the ID is locked once saved). Only that record changes in the file.
- **Delete an animal:** removes a record after a Yes/No confirmation showing the ID and name.
- **Automatic classification:** status and housing unit are calculated from the Recovery Score, never typed in. The same classification method is used for Add and Update.
- **Summary report:** the Generate Summary button shows the total animals, average age, average recovery score and the count per status on the form, and saves them to `summary.txt`.
- **Input validation:** the animal ID must be `WR-` followed by 4 digits and unique. Name and species must be 1-30 characters with no `|`. Age and score must be whole numbers from 0 to 100.
- **Error handling:** file problems (read-only or locked file, missing file) show a friendly message instead of crashing.

| Recovery Score | Status | Housing Unit |
|---|---|---|
| 0-19 | Critical | Intensive Care Unit |
| 20-39 | Serious | High-Dependency Ward |
| 40-59 | Stable | Recovery Ward |
| 60-79 | Recovering | Outdoor Enclosure |
| 80-100 | Release-Ready | Pre-Release Camp |

## File formats

### animals.txt
Plain text, UTF-8, one animal per line, with no header line and no blank lines. Each line has seven fields separated by the pipe character `|`, in this order: `ID|Name|Species|Age|Score|Status|Housing Unit`.

```
WR-0001|Thabo|African Penguin|4|85|Release-Ready|Pre-Release Camp
WR-0002|Naledi|Serval|3|62|Recovering|Outdoor Enclosure
WR-0004|Zola|Cape Vulture|12|19|Critical|Intensive Care Unit
```

### summary.txt
A plain text report created beside the `.exe` each time **Generate Summary** is clicked. It is overwritten every time, never appended to. It contains the centre name, a `yyyy-MM-dd HH:mm` timestamp, the total number of animals, the average age and average recovery score (two decimals, full stop as the decimal separator on any regional setting), and the count for all five statuses, including those at 0. With no animals, the counts are 0 and the averages show `N/A`.

```
BAOBAB RIDGE WILDLIFE REHABILITATION CENTRE
ANIMAL SUMMARY REPORT
Generated: 2026-10-14 09:32
----------------------------------------
Total animals:            12
Average age (years):      7.75
Average recovery score:   54.00
----------------------------------------
Animals per status:
  Critical:               2
  Serious:                2
  Stable:                 2
  Recovering:             3
  Release-Ready:          3
```
## Known limitations

- Data is stored in plain text files, so there is no database, no search or filtering, and no undo. Deleted records are gone for good.
- Update and Delete rewrite the whole of `animals.txt`. If another program locks the file, the change is not saved and an error message is shown.
- The `|` character cannot be used in a name or species, because it is the field separator.
- The program is not designed for several users editing the same file at once.
- `summary.txt` only reflects the data at the moment the report was generated.
