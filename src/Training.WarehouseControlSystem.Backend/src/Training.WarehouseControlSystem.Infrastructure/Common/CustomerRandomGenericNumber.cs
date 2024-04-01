namespace Training.WarehouseControlSystem.Infrastructure.Common;

public static class CustomerRandomGenericNumber
{
    public static int GenerateNumber(List<int> existingNums)
    {
        Random random = new Random();
        
        again:
        var randomNumber = random.Next(100000, 999999);
        
        if(existingNums.Contains(randomNumber))
            goto again;
        return randomNumber;
    }
}