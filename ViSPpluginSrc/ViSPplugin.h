#pragma once

extern "C" {
	// Calculates the position of a 3D point
	// Return true if calculatons is successful, false if not
	bool GetProjection(double oX, double oY, double oZ, double* results, int size);
}
