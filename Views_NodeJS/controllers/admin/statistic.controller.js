const commonApi = require('../../apis/common.api');

exports.getRegionStatistic = async (req, res) => {
	try {
		const provinces = (await (await commonApi.getAllProvince())?.data) || [];

		return res.render('./admin/region.pug', {
			title: 'Smarket | Thống kê theo vùng',
			provinces,
		});
	} catch (error) {
		console.error('Function getRegionStatistic Error: ', error);
		return res.render('404');
	}
};