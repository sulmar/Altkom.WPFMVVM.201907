select 
	year(CreatedAt) as [year], 
	month(CreatedAt) as [month], 
	count(*) as quantity 
from 
	Vehicles 
where 
	IsRemoved = @IsRemoved 
group by 
	year(CreatedAt), month(CreatedAt)