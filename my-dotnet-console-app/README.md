# Apple Insurance Pricing Engine

## Parameters

- **NumberOfApples**: Total apples insured.
- **Month**: Month of insurance (1 = January, ..., 12 = December).
- **DistanceMiles**: Distance apples are transported from orchard (in miles).
- **LockedCompoundWithCCTV**: Are apples stored in a locked compound with CCTV? (`true` or `false`).

## Pricing Rules

- £0.01 per apple.
- 5% discount for 1,000–10,000 apples.
- 8% discount for >10,000 apples.
- 10% loading for January–March.
- -10% loading for April–September.
- £5.00 loading per 1,000 apples if distance >100 miles.
- £0.20 discount per 500 apples (max £3.50) if stored in locked compound with CCTV.

## Input JSON Structure

```json
{
  "NumberOfApples": 12000,
  "Month": 2,
  "DistanceMiles": 150,
  "LockedCompoundWithCCTV": true
}
```

## Example Usage

1. Save your parameters in a file called `input.json`.
2. Run the application:

```sh
dotnet run --project my-dotnet-console-app input.json
```

The final insurance premium will be printed to the console.