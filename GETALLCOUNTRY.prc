CREATE OR REPLACE PROCEDURE ICCD.GetAllCountry(
    p_country_cursor OUT SYS_REFCURSOR
) AS
BEGIN
    OPEN p_country_cursor FOR
    SELECT 
COUNTRYID, COUNTRYNAME
FROM ICCD.TBL_COUNTRY;

END GetAllCountry;
/