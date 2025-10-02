# Apple Insurance Pricing Engine

## Parameters

- **NumberOfApples**: Total apples insured.
- **Month**: Month of insurance (1 = January, ..., 12 = December).
- **DistanceMiles**: Distance apples are transported from orchard (in miles).
- **LockedCompoundWithCCTV**: Are apples stored in a locked compound with CCTV? (`true` or `false`).

## Pricing Rules & Calculation Order

1. **Base Premium:** £0.01 per apple.
2. **Distance Loading:** If apples are transported more than 100 miles, a loading of £5.00 is applied for every 1,000 apples.  
   _This loading is applied **before** any discounts or seasonal loadings._
3. **Discounts for Quantity:**
   - 5% discount for 1,000–10,000 apples.
   - 8% discount for >10,000 apples.
4. **Seasonal Loading:**
   - 10% loading for January–March.
   - -10% loading for April–September.
5. **Locked Compound Discount:** If stored in a locked compound with CCTV, a discount of £0.20 per 500 apples is applied, up to a maximum of £3.50.

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