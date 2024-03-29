set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO


ALTER PROCEDURE [dbo].[OrderDetailPro](
	@OrderId int = 1)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure hereD 
	SELECT B.NAME CUS_NAME , B.ADDRESS CUS_ADDRESS , B.PHONENO , D.NAME PRODUCT_NAME , E.NAME UNIT_NAME, C.AMOUNT, C.PRICE 
	FROM ORDERS A, CUSTOMERS B , ORDERDETAILS C , ProductS D , ProductUnitS E
	 WHERE A.ORDERID =  @OrderId 
		AND	A.ORDERID = C.ORDERID
	 AND A.CUSTOMERID = B.CUSTOMERID
	 AND C.PRODUCTID = D.PRODUCTID
	 AND C.ProductUnitId = E.PRODUCTUNITID
END








