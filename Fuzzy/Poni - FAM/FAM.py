import numpy as np

# Correlation Minimum Encoding
def cme(a, b):
	m = np.zeros((len(a), len(b)))
	a = a.T
	for x in range(len(b)):
		for y in range(len(a)):
			m[y, x] = min(a[y], b[x]);
	return m

# Correlation Product Encoding
def cpe(a, b):
	m = np.zeros((len(a), len(b)))
	a = a.T
	for x in range(len(b)):
		for y in range(len(a)):
			m[y, x] = a[y] * b[x]
	return m

# Max-min composition
def mmc(array, m, find):
	if 'b' in find:
		temp = np.zeros(array.shape[0])
		hasil = np.zeros(m.shape[1])
		for j in range(m.shape[1]):
			for i in range(array.shape[0]):
				temp[i] = min(array[i], m[i, j])
			hasil[j] = max(temp)
	elif 'a' in find:
		m = m.T
		temp = np.zeros(array.shape[0])
		hasil = np.zeros(m.shape[1])
		for j in range(m.shape[1]):
			for i in range(m.shape[0]):
				temp[i] = min(array[i], m[i, j])
			hasil[j] = max(temp)
	return hasil
		
# Max-Product composition
def mpc(array, m, find):
	if 'b' in find:
		temp = np.zeros(array.shape[0])
		hasil = np.zeros(m.shape[1])
		for j in range(m.shape[1]):
			for i in range(array.shape[0]):
				temp[i] = array[i] * m[i, j]
			hasil[j] = max(temp)
	elif 'a' in find:
		m = m.T
		temp = np.zeros(array.shape[0])
		hasil = np.zeros(m.shape[1])
		for j in range(m.shape[1]):
			for i in range(m.shape[0]):
				temp[i] = array[i] * m[i, j]
			hasil[j] = max(temp)
	return hasil

# Superimposing FAM rules - max min
def super_cme(a, b, a_aksen):
	m = np.zeros((len(a), len(a[0]), len(b[0])))
	B = np.zeros((len(a), len(b[0])))
	b_ang = np.zeros(len(b[0]))
	temp = np.zeros((len(b[0]), len(b[0])))
	for x in range(len(a)):
		m[x] = cme(a[x], b[x])
		B[x] = mmc(a_aksen, m[x], 'b')
		if x < len(b[0]):
			for y in range(len(b[0])):
				temp[x, y] = B[y, x]
			b_ang[x] = max(temp[x])
	return m, b_ang, max(b_ang)

# Superimposing FAM rules - contoh 2
def super_cpe(a, b, a_aksen):
	m = np.zeros((len(a), len(a[0]), len(b[0])))
	B = np.zeros((len(a), len(b[0])))
	b_ang = np.zeros(len(b[0]))
	for x in range(len(a)):
		m[x] = cme(a[x], b[x])
		B[x] = np.dot(a_aksen, m[x])
	for x in range(len(a)):
		if x < len(b[0]):
			for y in range(len(b[0])):
				b_ang[x] += B[x, y];
	return m, b_ang, max(b_ang)

# KASUS 2
# ==============================
# A = np.array([
# 	[1, 0, 0, 1, 0, 0, 1, 0, 0],
# 	[1, 0, 0, 1, 0, 0, 0, 1, 0],
# 	[1, 0, 0, 1, 0, 0, 0, 0, 1],
# 	[1, 0, 0, 0, 1, 0, 1, 0, 0],
# 	[1, 0, 0, 0, 1, 0, 0, 1, 0],
# 	[1, 0, 0, 0, 1, 0, 0, 0, 1],
# 	[1, 0, 0, 0, 0, 1, 1, 0, 0],
# 	[1, 0, 0, 0, 0, 1, 0, 1, 0],
# 	[1, 0, 0, 0, 0, 1, 0, 0, 1],
# 	[0, 1, 0, 1, 0, 0, 1, 0, 0],
# 	[0, 1, 0, 1, 0, 0, 0, 1, 0],
# 	[0, 1, 0, 1, 0, 0, 0, 0, 1],
# 	[0, 1, 0, 0, 1, 0, 1, 0, 0],
# 	[0, 1, 0, 0, 1, 0, 0, 1, 0],
# 	[0, 1, 0, 0, 1, 0, 0, 0, 1],
# 	[0, 1, 0, 0, 0, 1, 1, 0, 0],
# 	[0, 1, 0, 0, 0, 1, 0, 1, 0],
# 	[0, 1, 0, 0, 0, 1, 0, 0, 1],
# 	[0, 0, 1, 1, 0, 0, 1, 0, 0],
# 	[0, 0, 1, 1, 0, 0, 0, 1, 0],
# 	[0, 0, 1, 1, 0, 0, 0, 0, 1],
# 	[0, 0, 1, 0, 1, 0, 1, 0, 0],
# 	[0, 0, 1, 0, 1, 0, 0, 1, 0],
# 	[0, 0, 1, 0, 1, 0, 0, 0, 1],
# 	[0, 0, 1, 0, 0, 1, 1, 0, 0],
# 	[0, 0, 1, 0, 0, 1, 0, 1, 0],
# 	[0, 0, 1, 0, 0, 1, 0, 0, 1]]
# 	)
# B = np.array([
# 	[1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0],
# 	[0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0],
# 	[0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0],
# 	[0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0],
# 	[0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0],
# 	[0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0],
# 	[0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0],
# 	[0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0],
# 	[0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0],
# 	[0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0],
# 	[0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0],
# 	[0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0],
# 	[0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0],
# 	[0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0],
# 	[0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0],
# 	[0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0],
# 	[0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0],
# 	[0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0],
# 	[0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0],
# 	[0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0],
# 	[0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0],
# 	[0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0],
# 	[0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0],
# 	[0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0],
# 	[0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0],
# 	[0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0],
# 	[0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1]]
# 	)
# # b_aksen = np.array([0.25, 0.75, 0, 0, 0.267, 0.733, 0, 0.75, 0.25])
# b_aksen = np.array([0,1,0,0,0,1,0,1,0])
# nilaiBDiskret = np.array([
# 	148.00, 150.90, 146.50, 143.10, 146.53, 
# 	142.73, 136.73, 140.77, 135.97, 149.73, 
# 	153.27, 152.13, 148.00, 150.63, 147.63,
# 	141.67, 145.67, 140.20, 142.10, 146.53,
# 	142.17, 138.70, 141.40, 138.30, 133.33,
# 	138.53, 133.77])
		
# fam, output, max_value = super_cpe(A, B, b_aksen)


# CONTOH
# ==============================
# A = np.array([
# 		[1, 0, 0],
# 		[0, 1, 0],
# 		[0, 0, 1],
# 		[0.125, 0.25, 0.875],
# 		[0.875, 0.25, 0.125]]
# 	)
# B = np.array([
# 		[1, 0, 0],
# 		[0, 1, 0],
# 		[0, 0, 1],
# 		[0, 0.2, 0.8],
# 		[0.8, 0.2, 0]]
# 	)
# b_aksen = np.array([0.389, 0.700, 0.611])
# nilaiBDiskret = np.array([5, 20, 60])
		
# fam, output, max_value = super_cme(rulesA, rulesB, b_aksen)


index = output.tolist().index(max_value)
print('Matriks FAM\n', fam)
print('Hasil output\n', output)
print('Hasil Defuzzyfication\n', nilaiBDiskret[index])