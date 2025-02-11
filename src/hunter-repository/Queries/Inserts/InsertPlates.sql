
DECLARE @Results TABLE (CarPlate VARCHAR(20), Status VARCHAR(50));

DECLARE @CarPlate VARCHAR(20);
DECLARE PlateCursor CURSOR FOR SELECT CarPlate FROM @CarPlates;

OPEN PlateCursor;
FETCH NEXT FROM PlateCursor INTO @CarPlate;

WHILE @@FETCH_STATUS = 0
BEGIN
    IF NOT EXISTS (SELECT 1 FROM Vehicles WHERE CarPlate = @CarPlate)
    BEGIN
        INSERT INTO Vehicles (
            Company, CustomerName, UF, City, CarPlate, Chassis, Renavan, AutoBrand, AutoModel, 
            YearManufactore, YearModel, Folder, ProcessNumer, Status
        )
        VALUES (
            @Company, @CustomerName, @UF, @City, @CarPlate, @Chassis, @Renavan, @AutoBrand, @AutoModel, 
            @YearManufactore, @YearModel, @Folder, @ProcessNumer, @Status
        );
        INSERT INTO @Results VALUES (@CarPlate, 'Inserted');
    END
    ELSE
    BEGIN
        INSERT INTO @Results VALUES (@CarPlate, 'Already Exists');
    END

    FETCH NEXT FROM PlateCursor INTO @CarPlate;
END

CLOSE PlateCursor;
DEALLOCATE PlateCursor;

SELECT * FROM @Results;
