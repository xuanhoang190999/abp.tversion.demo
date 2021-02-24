import { Pipe, PipeTransform } from '@angular/core';
import { HttpClient, HttpParams, HttpHeaders } from '@angular/common/http';

/*
 * Usage:
 *   url | imageResize:width:height
 * Example:
 *   {{ url |  imageResize:width:height}}
 *   formats to: url?width=width&height=height&mode=crop
*/
@Pipe({ name: 'imageResize' })
export class ImageResizePipe implements PipeTransform {

	transform(url: string, width?: number, height?: number, mode?: string): string {
		let httpParams = new HttpParams();
		if (width || height) {
			url = url + "?";

			if (width) {
				httpParams = httpParams.append('width', width.toString());
			}

			if (height) {
				httpParams = httpParams.append('height', height.toString());
			}

			if (mode) {
				httpParams = httpParams.append('mode', mode);
			} else {
				httpParams = httpParams.append('mode', 'pad');
			}
		}

		return url + httpParams.toString();
	}
}