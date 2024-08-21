CREATE OR REPLACE PROCEDURE ICCD.GetCitiesByCountry (
    p_country_name IN VARCHAR2,
    p_city_cursor OUT SYS_REFCURSOR
) AS
BEGIN
    OPEN p_city_cursor FOR
    SELECT CityName FROM TBL_CITY WHERE COUNTRYID = p_country_name;
END;
/